using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateAsync(Customer customer);
    }
}
