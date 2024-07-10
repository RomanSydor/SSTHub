using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Hub;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Application.Services
{
    public class HubService : IHubService
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HubService(SSTHubDbContext sSTHubDbContext, IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _sSTHubDbContext = sSTHubDbContext;
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
            var hub = await _sSTHubDbContext
                            .Hubs
                            .Where(h => h.Id == id)
                            .SingleOrDefaultAsync();

            return _mapper.Map<HubDetailsViewModel>(hub);
        }

        public async Task UpdateAsync(int id, HubEditItemViewModel editItemViewModel)
        {
            var hub = await _sSTHubDbContext
                .Hubs
                .Where(h => h.Id == id)
                .SingleOrDefaultAsync();

            if (hub != null)
            {
                hub.Name = editItemViewModel.Name;

                _unitOfWork.HubRepository.Update(hub);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task ChangeActiveStatusAsync(int id)
        {
            var hub = await _sSTHubDbContext
                .Hubs
                .Where(h => h.Id == id)                      
                .SingleOrDefaultAsync();

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
            var hubs = await _sSTHubDbContext
                .Hubs
                .Where(h => h.OrganizationId == organizationId)
                .Skip(amount * page)
                .Take(amount)
                .ToListAsync();

            return _mapper.Map<IEnumerable<HubListItemViewModel>>(hubs);
        }
    }
}
