using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Enums;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Event;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Application.Services
{
    public class EventService : IEventService
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EventService(SSTHubDbContext sSTHubDbContext,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _sSTHubDbContext = sSTHubDbContext;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EventListItemViewModel>> GetByHubIdAsync(int hubId, int amount, int page)
        {
            var @event = await _sSTHubDbContext
               .Events
               .Where(e => e.HubId == hubId)
               .Skip(amount * page)
               .Take(amount)
               .ToListAsync();

            return _mapper.Map<IEnumerable<EventListItemViewModel>>(@event);
        }

        public async Task<EventDetailsViewModel> GetByIdAsync(int id)
        {
            var @event = await _sSTHubDbContext
                .Events
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();

            return _mapper.Map<EventDetailsViewModel>(@event);
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
            var @event = await _sSTHubDbContext
                .Events
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();

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
