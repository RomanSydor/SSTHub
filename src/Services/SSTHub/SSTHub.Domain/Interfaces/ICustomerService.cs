using SSTHub.Domain.ViewModels.Customer;

namespace SSTHub.Domain.Interfaces
{
    public interface ICustomerService
    {
        Task<int> CreateAsync(CustomerCreateViewModel createViewModel);
        Task<IEnumerable<CustomerListItemViewModel>> GetByHubIdAsync(int hubId);
        Task<IEnumerable<CustomerListItemViewModel>> GetByOrganizationIdAsync(int organizationId);
    }
}
