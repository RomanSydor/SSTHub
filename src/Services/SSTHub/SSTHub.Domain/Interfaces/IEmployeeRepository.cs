using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task CreateAsync(Employee employee);
        void Update(Employee employee);
        Task<IEnumerable<Employee>> GetByOrganizationIdAsync(int organizationId, int amount, int page);
        Task<Employee> GetByIdAsync(int id);
    }
}
