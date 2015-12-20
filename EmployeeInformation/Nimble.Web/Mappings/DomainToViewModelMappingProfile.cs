using AutoMapper;
using Nimble.Models.Entity;
using Nimble.Web.ViewModels;

namespace Nimble.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            
            Mapper.CreateMap<Employee, EmployeeViewModel>(); 

        }
     
    }
}