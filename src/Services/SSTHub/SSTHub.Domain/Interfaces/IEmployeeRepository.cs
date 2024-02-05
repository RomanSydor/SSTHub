using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<bool> UpdateAsync(Employee employee);
    }
}
