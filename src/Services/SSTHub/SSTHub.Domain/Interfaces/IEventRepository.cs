using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces
{
    public interface IEventRepository
    {
        Task CreateAsync(Event @event);
        void Update(Event @event);
        Task<IEnumerable<Event>> GetByHubIdAsync(int hubId, int amount, int page);
        Task<IEnumerable<Event>> GetByOrganizationIdAsync(int organizationId, int amount, int page);
        Task<Event> GetByIdAsync(int id);
    }
}
