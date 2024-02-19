using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces
{
    public interface IHubRepository
    {
        Task<int> CreateAsync(Hub hub);
    }
}
