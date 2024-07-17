using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Enums;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Event;

namespace SSTHub.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EventListItemViewModel>> GetByHubIdAsync(int hubId, int amount, int page)
        {
            var @event = await _unitOfWork.EventRepository.GetByHubIdAsync(hubId, amount, page);
            return _mapper.Map<IEnumerable<EventListItemViewModel>>(@event);
        }

        public async Task<EventDetailsViewModel> GetByIdAsync(int id)
        {
            var @event = await _unitOfWork.EventRepository.GetByIdAsync(id);
            return _mapper.Map<EventDetailsViewModel>(@event);
        }

        public async Task<IEnumerable<EventListItemViewModel>> GetByOrganizationIdAsync(int organizationId, int amount, int page)
        {
            var events = await _unitOfWork.EventRepository.GetByOrganizationIdAsync(organizationId, amount, page);
            return _mapper.Map<IEnumerable<EventListItemViewModel>>(events);
        }

        public async Task<int> CreateAsync(EventCreateViewModel createViewModel)
        {
            var @event = _mapper.Map<Event>(createViewModel);
            @event.CreatedAt = DateTime.Now;
            @event.Status = EventStatuses.Created;

            await _unitOfWork.EventRepository.CreateAsync(@event);
            await _unitOfWork.SaveChangesAsync();

            return @event.Id;
        }

        public async Task UpdateAsync(int id, EventEditItemViewModel editItemViewModel)
        {
            var @event = await _unitOfWork.EventRepository.GetByIdAsync(id);

            if (@event != null)
            {
                @event.StartAt = editItemViewModel.StartAt;
                @event.Status = editItemViewModel.Status;
                @event.CustomerId = editItemViewModel.CustomerId;
                @event.EmployeeId = editItemViewModel.EmployeeId;
                @event.ServiceId = editItemViewModel.ServiceId;

                _unitOfWork.EventRepository.Update(@event);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
