using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.ViewModels.Hub;

namespace SSTHub.Infrastucture.MappingProfiles
{
    public class HubProfile : Profile
    {
        public HubProfile() 
        {
            CreateMap<Hub, HubDetailsViewModel>();

            CreateMap<HubCreateViewModel, Hub>();
        }
    }
}
