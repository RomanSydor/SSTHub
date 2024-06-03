using SSTHub.Domain.ViewModels.Customer;

namespace SSTHub.Domain.Interfaces
{
    public interface ICustomerService
    {
        Task<int> CreateAsync(CustomerCreateViewModel createViewModel);
    }
}
