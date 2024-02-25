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

        public HubService(IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAsync(HubCreateViewModel createViewModel)
        {
            var hub = _mapper.Map<Hub>(createViewModel);
            hub.IsActive = true;
            hub.CreatedAt = DateTime.UtcNow;

            var hubId = await _unitOfWork.HubRepository.CreateAsync(hub);
            await _unitOfWork.SaveChangesAsync();

            return hubId;
        }
    }
}
