using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.ViewModels.Hub;
using SSTHub.Infrastucture.MappingProfiles.CustomConverters;
using System.Collections.Immutable;

namespace SSTHub.Infrastucture.MappingProfiles
{
    public class HubProfile : Profile
    {
        public HubProfile() 
        {
            CreateMap<ImmutableList<Hub>, ImmutableList<HubListItemViewModel>>()
              .ConvertUsing(new ImmutableListConverter<Hub, HubListItemViewModel>());
            CreateMap<ImmutableList<Hub>, ImmutableList<HubDetailsViewModel>>()
               .ConvertUsing(new ImmutableListConverter<Hub, HubDetailsViewModel>());

            CreateMap<Hub, HubListItemViewModel>();
            CreateMap<Hub, HubDetailsViewModel>();

            CreateMap<HubCreateViewModel, Hub>();
        }
    }
}
