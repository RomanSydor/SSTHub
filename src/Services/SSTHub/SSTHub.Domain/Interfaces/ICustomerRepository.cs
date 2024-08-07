using SSTHub.Domain.Entities;
using System.Collections.Immutable;

namespace SSTHub.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateAsync(Customer customer);
        Task<ImmutableList<Customer>> GetByHubIdAsync(int hubId);
        Task<ImmutableList<Customer>> GetByOrganizationIdAsync(int organizationId);
    }
}
