using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Infrastucture.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly SSTHubDbContext _sSTHubDbContext;

        public ServiceRepository(SSTHubDbContext sSTHubDbContext)
        {
            _sSTHubDbContext = sSTHubDbContext;
        }

        public async Task CreateAsync(Service service)
        {
            await _sSTHubDbContext.AddAsync(service);
        }

        public void Update(Service service)
        {
            _sSTHubDbContext.Update(service);
        }
    }
}
