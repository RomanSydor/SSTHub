using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task CreateAsync(Employee employee);
        void Update(Employee employee);
        Task<IEnumerable<Employee>> GetByOrganizationIdAsync(int organizationId);
        Task<Employee> GetByIdAsync(int id);
    }
}
