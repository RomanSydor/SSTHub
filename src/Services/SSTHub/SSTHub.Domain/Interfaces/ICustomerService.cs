using SSTHub.Domain.ViewModels.Customer;
using System.Collections.Immutable;

namespace SSTHub.Domain.Interfaces
{
    public interface ICustomerService
    {
        Task<int> CreateAsync(CustomerCreateViewModel createViewModel);
        Task<ImmutableList<CustomerListItemViewModel>> GetByHubIdAsync(int hubId);
        Task<ImmutableList<CustomerListItemViewModel>> GetByOrganizationIdAsync(int organizationId);
    }
}
