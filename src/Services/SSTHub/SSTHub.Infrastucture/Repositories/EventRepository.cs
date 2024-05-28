using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Infrastucture.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        public EventRepository(SSTHubDbContext sSTHubDbContext)
        {
            _sSTHubDbContext = sSTHubDbContext;
        }

        public async Task CreateAsync(Event @event)
        {
            await _sSTHubDbContext.AddAsync(@event);
        }

        public void Update(Event @event)
        {
            _sSTHubDbContext.Update(@event);
        }
    }
}
