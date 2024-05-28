using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.ViewModels.Event;

namespace SSTHub.Infrastucture.MappingProfiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventListItemViewModel>();
            CreateMap<Event, EventDetailsViewModel>();

            CreateMap<EventCreateViewModel, Event>();
        }
    }
}
