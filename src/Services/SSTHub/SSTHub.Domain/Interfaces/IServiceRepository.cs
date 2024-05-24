using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces
{
    public interface IServiceRepository
    {
        Task CreateAsync(Service service);
        void Update(Service service);
    }
}
