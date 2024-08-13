using SSTHub.Domain.Entities;
using System.Collections.Immutable;

namespace SSTHub.Domain.Interfaces
{
    public interface IEventRepository
    {
        Task CreateAsync(Event @event);
        Task<ImmutableList<Event>> GetByHubIdAsync(int hubId);
        Task<ImmutableList<Event>> GetByOrganizationIdAsync(int organizationId);
        Task<Event> GetByIdAsync(int id);
    }
}
