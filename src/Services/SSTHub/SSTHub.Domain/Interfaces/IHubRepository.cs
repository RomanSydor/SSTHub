using SSTHub.Domain.Entities;
using System.Collections.Immutable;

namespace SSTHub.Domain.Interfaces
{
    public interface IHubRepository
    {
        Task CreateAsync(Hub hub);
        Task<Hub> GetByIdAsync(int id);
        Task<ImmutableList<Hub>> GetByOrganizationIdAsync(int organizationId);

    }
}
