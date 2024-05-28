using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces
{
    public interface IEventRepository
    {
        Task CreateAsync(Event @event);
        void Update(Event @event);
    }
}
