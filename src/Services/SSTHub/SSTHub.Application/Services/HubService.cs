using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Hub;

namespace SSTHub.Application.Services
{
    public class HubService : IHubService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HubService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAsync(HubCreateViewModel createViewModel)
        {
            var hub = _mapper.Map<Hub>(createViewModel);
            hub.IsActive = true;
            hub.CreatedAt = DateTime.UtcNow;

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

            if (hub != null)
            {
                hub.Name = editItemViewModel.Name;

                _unitOfWork.HubRepository.Update(hub);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task ChangeActiveStatusAsync(int id)
        {
            var hub = await _unitOfWork.HubRepository.GetByIdAsync(id);

            if (hub != null)
            {
                if (hub.IsActive)
                {
                    hub.IsActive = false;
                }
                else
                {
                    hub.IsActive = true;
                }

                _unitOfWork.HubRepository.Update(hub);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<HubListItemViewModel>> GetByOrganizationIdAsync(int organizationId, int amount, int page)
        {
            var hubs = await _unitOfWork.HubRepository.GetByOrganizationIdAsync(organizationId, amount, page);
            return _mapper.Map<IEnumerable<HubListItemViewModel>>(hubs);
        }
    }
}
