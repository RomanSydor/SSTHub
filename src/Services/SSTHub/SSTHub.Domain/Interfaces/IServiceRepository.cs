using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces
{
    public interface IServiceRepository
    {
        Task CreateAsync(Service service);
        void Update(Service service);
        Task<Service> GetByIdAsync(int id);
        Task<IEnumerable<Service>> GetByOrganizationIdAsync(int organizationId);
        Task<IEnumerable<Service>> GetByEmployeeIdAsync(int employeeId);
    }
}
