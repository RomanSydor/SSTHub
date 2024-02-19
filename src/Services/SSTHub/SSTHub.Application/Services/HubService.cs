using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Hub;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Application.Services
{
    public class HubService : IHubService
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly IMapper _mapper;
        private readonly IHubRepository _hubRepository;

        public HubService(SSTHubDbContext sSTHubDbContext,
            IMapper mapper,
            IHubRepository hubRepository)
        {
            _sSTHubDbContext = sSTHubDbContext;
            _mapper = mapper;
            _hubRepository = hubRepository;
        }
        public Task<int> CreateAsync(HubCreateViewModel createViewModel)
        {
            var hub = _mapper.Map<Hub>(createViewModel);
            hub.IsActive = true;
            hub.CreatedAt = DateTime.UtcNow;

            var hubId = _hubRepository.CreateAsync(hub);
            return hubId;
        }
    }
}
