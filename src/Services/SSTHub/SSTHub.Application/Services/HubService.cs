using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Hub;
using System.Collections.Immutable;

namespace SSTHub.Application.Services
{
    public class HubService(IMapper _mapper,
        IUnitOfWork _unitOfWork,
        IDateTimeService _dateTimeService) : IHubService
    {
        public async Task<int> CreateAsync(HubCreateViewModel createViewModel)
        {
            var hub = _mapper.Map<Hub>(createViewModel);
            hub.IsActive = true;
            hub.CreatedAt = _dateTimeService.GetDateTimeNow();

            await _unitOfWork.HubRepository.CreateAsync(hub);
            await _unitOfWork.SaveChangesAsync();

            return hub.Id;
        }

        public async Task<HubDetailsViewModel> GetByIdAsync(int id)
        {
            var hub = await _unitOfWork.HubRepository.GetByIdAsync(id);
            return _mapper.Map<HubDetailsViewModel>(hub);
        }

        public async Task UpdateAsync(int id, HubEditItemViewModel editItemViewModel)
        {
            var hub = await _unitOfWork.HubRepository.GetByIdAsync(id);
            hub.Name = editItemViewModel.Name;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ChangeActiveStatusAsync(int id)
        {
            var hub = await _unitOfWork.HubRepository.GetByIdAsync(id);
            hub.IsActive = !hub.IsActive;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ImmutableList<HubListItemViewModel>> GetByOrganizationIdAsync(int organizationId)
        {
            var hubs = await _unitOfWork.HubRepository.GetByOrganizationIdAsync(organizationId);
            return _mapper.Map<ImmutableList<HubListItemViewModel>>(hubs);
        }
    }
}
