using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces
{
    public interface IOrganizationRepositiry
    {
        Task CreateAsync(Organization organization);
        void Update(Organization organization);
        Task<Organization> GetByIdAsync(int id);
    }
}
