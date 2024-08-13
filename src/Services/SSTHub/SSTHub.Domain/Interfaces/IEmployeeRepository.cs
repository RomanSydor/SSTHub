using SSTHub.Domain.Entities;
using System.Collections.Immutable;

namespace SSTHub.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task CreateAsync(Employee employee);
        Task<ImmutableList<Employee>> GetByOrganizationIdAsync(int organizationId);
        Task<Employee> GetByIdAsync(int id);
    }
}
