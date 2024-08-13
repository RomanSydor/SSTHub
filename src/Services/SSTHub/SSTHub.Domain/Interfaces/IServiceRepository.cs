using SSTHub.Domain.Entities;
using System.Collections.Immutable;

namespace SSTHub.Domain.Interfaces
{
    public interface IServiceRepository
    {
        Task CreateAsync(Service service);
        Task<Service> GetByIdAsync(int id);
        Task<ImmutableList<Service>> GetByOrganizationIdAsync(int organizationId);
        Task<ImmutableList<Service>> GetByEmployeeIdAsync(int employeeId);
    }
}
