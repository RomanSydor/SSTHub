using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.ViewModels.Organization;

namespace SSTHub.Infrastructure.MappingProfiles
{
    public class OrganizationProfile : Profile  
    {
        public OrganizationProfile() 
        {
            CreateMap<Organization, OrganizationDetailsViewModel>();

            CreateMap<OrganizationCreateViewModel, Organization>();
        }
    }
}
