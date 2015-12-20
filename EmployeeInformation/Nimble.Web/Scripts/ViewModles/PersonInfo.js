/// <reference path="../jquery-2.1.3.min.js" />
/// <reference path="../knockout-3.2.0.js" />


(function () {
    var viewModel = function () {
        var self = this;

        var IsUpdatable = false;
        
       
        self.Id = ko.observable(0);
        self.FirstName = ko.observable("").extend({ required: true });
        self.LastName = ko.observable("");
        self.DOB = ko.observable("");
        self.Basic = ko.observable("");
        self.Allowance = ko.observable("");
        self.Communication = ko.observable("");
        self.PermanentCountry = ko.observable("");
        self.PermanentCity = ko.observable("");
        self.PermanentState = ko.observable("");
        self.PermanentStreet = ko.observable("");
        self.CurrentCountry = ko.observable("");
        self.CurrentCity = ko.observable("");
        self.CurrentState = ko.observable("");
        self.CurrentStreet = ko.observable("");
        //self.add = function () {
        //    debugger;
        //    self.Id = "";
        //    self.FirstName = "";
        //    self.LastName = "";
        //    self.DOB = "";
        //    self.Basic = "";
        //    self.Allowance = "";
        //    self.Communication = "";
        //    self.PermanentCountry = "";
        //    self.PermanentCity = "";
        //    self.PermanentState = "";
        //    self.PermanentStreet = "";
        //    self.CurrentCountry = "";
        //    self.CurrentCity = "";
        //    self.CurrentState = "";
        //    self.CurrentStreet = "";
        //}
        var PersonInfo = {
             Id: self.PersonId,
            FirstName: self.FirstName, 
            LastName: self.LastName,
            DOB: self.DOB,
            Basic: self.Basic,
            Allowance: self.Allowance,
            Communication: self.Communication,
            PermanentCountry: self.PermanentCountry,
            PermanentCity: self.PermanentCity,
            PermanentState: self.PermanentState,
            PermanentStreet: self.PermanentStreet,
            CurrentCountry: self.CurrentCountry,
            CurrentCity: self.CurrentCity,
            CurrentState: self.CurrentState,
            CurrentStreet: self.CurrentStreet,
        };
       
        self.Persons = ko.observable([]);

        self.Message = ko.observable("");

        self.Occupations =ko.observableArray(["Employeed","Self-Employeed","Doctor","Teacher","Other"]);
        self.SelectedOccupation = ko.observable();
      
        self.SelectedOccupation.subscribe(function (text) {
            self.Occupation(text);
        });

       
        self.States = ko.observableArray(["Jammu and Kashmir", "Delhi", "Himachal Pradesh",
        "Uttarakhand", "Punjab", "Hariyana", "Uttar Pradesh", "Rajasthan",
        "Madhya Pradesh", "Odissa", "Assam", "Arunchal Pradesh", "Manipur",
        "Mizoram", "Tripura", "Manupur", "Nagaland", "Jharkhand", "Bihar", "Sikkim",
        "Maharashtra", "Gujarat", "GOA", "Karnatak", "Telangana", "Simandhra",
        "Tamilnadu","Kerla","Andaman and Nikobar"]);

        self.SelectedState = ko.observable();
      
        self.SelectedState.subscribe(function (text) {
            self.State(text);
        });




        loadInformation();

        function loadInformation() {
         
            $.ajax({
                url: "/Home/GetAll",
                type:"GET"
            }).done(function (resp) {
                self.Persons(resp);
            }).error(function (err) {
                self.Message("Error! " + err.status);
            });
        }

        self.getSelected = function (obj) {
            self.Id(obj.Id);
            self.FirstName(obj.FirstName);
            self.LastName(obj.LastName);
            self.DOB(obj.DOB);
            self.Basic(obj.Basic);
            self.Allowance(obj.Allowance);
            self.Communication(obj.Communication);
            self.PermanentCountry(obj.PermanentCountry);
            self.PermanentCity(obj.PermanentCity);
            self.PermanentState(obj.PermanentState);
            self.PermanentStreet(obj.PermanentStreet);
            self.CurrentCountry(obj.CurrentCountry);
            self.CurrentCity(obj.CurrentCity);
            self.CurrentState(obj.CurrentState);
            self.CurrentStreet(obj.CurrentStreet); 
            IsUpdatable = true;
            $("#modalbox").modal("show");
        }

        self.save = function () {
            if (!IsUpdatable) {

                $.ajax({
                    url: "/Home/Add",
                    type: "POST",
                    data: PersonInfo,
                    datatype: "json",
                    contenttype: "application/json;utf-8"
                }).done(function (resp) {
                    self.Id(resp.Id);
                    $("#modalbox").modal("hide");
                    loadInformation();
                }).error(function (err) {
                    self.Message("Error! " + err.status);
                });
            } else {
                $.ajax({
                    url: "/Home/Update/" + self.Id(),
                    type: "POST",
                    data: PersonInfo,
                    datatype: "json",
                    contenttype: "application/json;utf-8"
                }).done(function (resp) {
                    $("#modalbox").modal("hide");
                    loadInformation();
                    IsUpdatable = false;
                }).error(function (err) {
                    self.Message("Error! " + err.status);
                    IsUpdatable = false;
                });

            }
        }

        self.delete = function (per) {
            $.ajax({
                url: "/Home/Delete/" + per.PersonId,
                type: "DELETE",
            }).done(function (resp) {
                loadInformation();
            }).error(function (err) {
                self.Message("Error! " + err.status);
            });
        }

    };
    ko.applyBindings(new viewModel());
})();