using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Event>> GetByHubIdAsync(int hubId, int amount, int page)
        {
            var @event = await _sSTHubDbContext
               .Events
               .Where(e => e.HubId == hubId)
               .Skip(amount * page)
               .Take(amount)
               .ToListAsync();

            return @event;
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            var @event = await _sSTHubDbContext
                .Events
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();

            return @event;
        }

        public async Task<IEnumerable<Event>> GetByOrganizationIdAsync(int organizationId, int amount, int page)
        {
            var hubIds = await _sSTHubDbContext
                .Hubs
                .Where(h => h.OrganizationId == organizationId)
                .Select(h => h.Id)
                .ToListAsync();

            var events = await _sSTHubDbContext
                .Events
                .Where(e => hubIds.Contains(e.HubId))
                .Skip(amount * page)
                .Take(amount)
                .ToListAsync();

            return events;
        }
    }
}
