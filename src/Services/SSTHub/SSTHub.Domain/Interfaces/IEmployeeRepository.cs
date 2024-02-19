using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<int> CreateAsync(Employee employee);
        Task<bool> UpdateAsync(Employee employee);
    }
}
