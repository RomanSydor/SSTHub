﻿using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Enums;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Event;
using System.Collections.Immutable;

namespace SSTHub.Application.Services
{
    public class EventService(IMapper _mapper,
        IUnitOfWork _unitOfWork,
        IDateTimeService _dateTimeService) : IEventService
    {
        public async Task<ImmutableList<EventListItemViewModel>> GetByHubIdAsync(int hubId)
        {
            var @event = await _unitOfWork.EventRepository.GetByHubIdAsync(hubId);
            return _mapper.Map<ImmutableList<EventListItemViewModel>>(@event);
        }

        public async Task<EventDetailsViewModel> GetByIdAsync(int id)
        {
            var @event = await _unitOfWork.EventRepository.GetByIdAsync(id);
            return _mapper.Map<EventDetailsViewModel>(@event);
        }

        public async Task<ImmutableList<EventListItemViewModel>> GetByOrganizationIdAsync(int organizationId)
        {
            var events = await _unitOfWork.EventRepository.GetByOrganizationIdAsync(organizationId);
            return _mapper.Map<ImmutableList<EventListItemViewModel>>(events);
        }

        public async Task<int> CreateAsync(EventCreateViewModel createViewModel)
        {
            var @event = _mapper.Map<Event>(createViewModel);
            @event.CreatedAt = _dateTimeService.GetDateTimeNow();
            @event.Status = EventStatuses.Created;

            await _unitOfWork.EventRepository.CreateAsync(@event);
            await _unitOfWork.SaveChangesAsync();

            return @event.Id;
        }

        public async Task UpdateAsync(int id, EventEditItemViewModel editItemViewModel)
        {
            var @event = await _unitOfWork.EventRepository.GetByIdAsync(id);
            @event.StartAt = editItemViewModel.StartAt;
            @event.Status = editItemViewModel.Status;
            @event.CustomerId = editItemViewModel.CustomerId;
            @event.EmployeeId = editItemViewModel.EmployeeId;
            @event.ServiceId = editItemViewModel.ServiceId;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
