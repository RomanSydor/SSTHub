using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces
{
    public interface IHubRepository
    {
        Task CreateAsync(Hub hub);
        void Update(Hub hub);

    }
}
