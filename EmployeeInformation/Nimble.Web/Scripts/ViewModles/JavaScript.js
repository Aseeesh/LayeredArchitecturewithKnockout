ko.validation.rules.pattern.message = 'Invalid.';


ko.validation.configure({
    registerExtenders: true,
    messagesOnModified: true,
    insertMessages: true,
    parseInputAttributes: true,
    messageTemplate: null
});

 
var self = this;var IsUpdatable = false;
        
var viewModel = {        
    Id: ko.observable().extend({ required: true }),
    FirstName: ko.observable().extend({ required: true }),
     LastName: ko.observable().extend({ required: true }),
    DOB: ko.observable().extend({ required: true }),
    Basic: ko.observable().extend({ required: true }),
  Allowance: ko.observable().extend({ required: true }),
     Communication: ko.observable().extend({ required: true }),
     PermanentCountry: ko.observable().extend({ required: true }),
     PermanentCity: ko.observable().extend({ required: true }),
     PermanentState: ko.observable().extend({ required: true }),
     PermanentStreet: ko.observable().extend({ required: true }),
    CurrentCountry: ko.observable().extend({ required: true }),
    CurrentCity: ko.observable().extend({ required: true }),
    CurrentState: ko.observable().extend({ required: true }),
    CurrentStreet: ko.observable().extend({ required: true }), 
    
};
 
 
viewModel.Persons = ko.observable([]);

viewModel.errors = ko.validation.group(viewModel);

loadInformation();

function loadInformation() {

    $.ajax({
        url: "/Home/GetAll",
        type: "GET"
    }).done(function (resp) {
        viewModel.Persons(resp);
    }).error(function (err) {
        self.Message("Error! " + err.status);
    });
}
 
viewModel.getSelected = function (obj) {
    viewModel.Id(obj.Id);
    viewModel.FirstName(obj.FirstName);
    viewModel.LastName(obj.LastName);
    viewModel.DOB(obj.DOB);
    viewModel.Basic(obj.Basic);
    viewModel.Allowance(obj.Allowance);
    viewModel.Communication(obj.Communication);
    viewModel.PermanentCountry(obj.PermanentCountry);
    viewModel.PermanentCity(obj.PermanentCity);
    viewModel.PermanentState(obj.PermanentState);
    viewModel.PermanentStreet(obj.PermanentStreet);
    viewModel.CurrentCountry(obj.CurrentCountry);
    viewModel.CurrentCity(obj.CurrentCity);
    viewModel.CurrentState(obj.CurrentState);
    viewModel.CurrentStreet(obj.CurrentStreet);
    IsUpdatable = true;
    $("#modalbox").modal("show");
}

viewModel.save = function () {
    if (viewModel.errors().length == 0) {
     debugger
        var datasent = {
            Id: viewModel.Id(),
            FirstName: viewModel.FirstName(),
            LastName: viewModel.LastName(),
            DOB: viewModel.DOB(),
            Basic: viewModel.Basic(),
            Allowance: viewModel.Allowance(),
            Communication: viewModel.Communication(),
            PermanentCountry: viewModel.PermanentCountry(),
            PermanentCity: viewModel.PermanentCity(),
            PermanentState: viewModel.PermanentState(),
            PermanentStreet: viewModel.PermanentStreet(),
            CurrentCountry: viewModel.CurrentCountry(),
            CurrentCity: viewModel.CurrentCity(),
            CurrentState: viewModel.CurrentState(),
            CurrentStreet: viewModel.CurrentStreet(),

        };
    if (!IsUpdatable) {

        $.ajax({
            url: "/Home/Add",
            type: "POST",
            data: datasent,
            datatype: "json",
            contenttype: "application/json;utf-8"
        }).done(function (resp) {
            viewModel.Id(resp.Id);
            $("#modalbox").modal("hide");
            loadInformation();
        }).error(function (err) {
            viewModel.Message("Error! " + err.status);
        });
    } else {
        $.ajax({
            url: "/Home/Update/" + viewModel.Id(),
            type: "POST",
            data: datasent,
            datatype: "json",
            contenttype: "application/json;utf-8"
        }).done(function (resp) {
            $("#modalbox").modal("hide");
            loadInformation();
            IsUpdatable = false;
        }).error(function (err) {
            viewModel.Message("Error! " + err.status);
            IsUpdatable = false;
        });

    }
    } else {
        // alert('Please check your submission.');
        viewModel.errors.showAllMessages();
    }
}
 
viewModel.add = function () {
  
    viewModel.Id("");
    viewModel.FirstName("");
    viewModel.LastName("");
    viewModel.DOB("");
    viewModel.Basic("");
    viewModel.Allowance("");
    viewModel.Communication("");
    viewModel.PermanentCountry("");
    viewModel.PermanentCity("");
    viewModel.PermanentState("");
    viewModel.PermanentStreet("");
    viewModel.CurrentCountry("");
    viewModel.CurrentCity("");
    viewModel.CurrentState("");
    viewModel.CurrentStreet("");
}
viewModel.delete = function (obj) {
    $.ajax({
        url: "/Home/Delete/" + obj.Id,
        type: "POST",
    }).done(function (resp) {
        loadInformation();
    }).error(function (err) {
      //  self.Message("Error! " + err.status);
    });
}

ko.applyBindings(viewModel);
