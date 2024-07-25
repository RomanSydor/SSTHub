using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateAsync(Customer customer);
        Task<IEnumerable<Customer>> GetByHubIdAsync(int hubId);
        Task<IEnumerable<Customer>> GetByOrganizationIdAsync(int organizationId);
    }
}
