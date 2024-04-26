using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Infrastucture.Repositories
{
    public class HubRepository : IHubRepository
    {
        private readonly SSTHubDbContext _sSTHubDbContext;

        public HubRepository(SSTHubDbContext sSTHubDbContext)
        {
            _sSTHubDbContext = sSTHubDbContext;
        }
        public async Task CreateAsync(Hub hub)
        {
            await _sSTHubDbContext.AddAsync(hub);
        }
    }
}
