using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces
{
    public interface IOrganizationRepository
    {
        Task CreateAsync(Organization organization);
        Task<Organization> GetByIdAsync(int id);
    }
}
