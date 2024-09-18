using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.ViewModels.Event;
using SSTHub.Infrastructure.MappingProfiles.CustomConverters;
using System.Collections.Immutable;

namespace SSTHub.Infrastructure.MappingProfiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<ImmutableList<Event>, ImmutableList<EventListItemViewModel>>()
               .ConvertUsing(new ImmutableListConverter<Event, EventListItemViewModel>());
            CreateMap<ImmutableList<Event>, ImmutableList<EventDetailsViewModel>>()
               .ConvertUsing(new ImmutableListConverter<Event, EventDetailsViewModel>());

            CreateMap<Event, EventListItemViewModel>();
            CreateMap<Event, EventDetailsViewModel>();

            CreateMap<EventCreateViewModel, Event>();
        }
    }
}
