using AutoMapper;
using Nimble.Models.Entity;
using Nimble.Web.ViewModels;

namespace SocialMedia.Mappings
{

    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
          
            Mapper.CreateMap<EmployeeViewModel, Employee>(); 
        }
    }
}