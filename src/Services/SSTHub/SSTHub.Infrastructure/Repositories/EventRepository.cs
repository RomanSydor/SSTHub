using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Infrastructure.Contexts;
using System.Collections.Immutable;

namespace SSTHub.Infrastructure.Repositories
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

        public async Task<ImmutableList<Event>> GetByHubIdAsync(int hubId)
        {
            var events = await _sSTHubDbContext
               .Events
               .Where(e => e.HubId == hubId)
               .ToListAsync();

            return events.ToImmutableList();
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            var @event = await _sSTHubDbContext
                .Events
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();

            return @event;
        }

        public async Task<ImmutableList<Event>> GetByOrganizationIdAsync(int organizationId)
        {
            var hubIds = await _sSTHubDbContext
                .Hubs
                .Where(h => h.OrganizationId == organizationId)
                .Select(h => h.Id)
                .ToListAsync();

            var events = await _sSTHubDbContext
                .Events
                .Where(e => hubIds.Contains(e.HubId))
                .ToListAsync();

            return events.ToImmutableList();
        }
    }
}
