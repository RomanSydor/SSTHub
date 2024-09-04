using AutoMapper;
using SSTHub.Identity.Models.Entities;
using SSTHub.Identity.Models.ViewModels;

namespace SSTHub.Identity.Infrastructure.MappingProfiles
{
    public class EmployeeUserProfile : Profile
    {
        public EmployeeUserProfile() 
        {
            CreateMap<OrganizationRegisterViewModel, EmployeeUser>();
        }
    }
}
