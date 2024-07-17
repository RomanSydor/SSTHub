using SSTHub.Domain.Entities;

namespace SSTHub.Domain.Interfaces
{
    public interface IServiceRepository
    {
        Task CreateAsync(Service service);
        void Update(Service service);
        Task<Service> GetByIdAsync(int id);
        Task<IEnumerable<Service>> GetByOrganizationIdAsync(int organizationId, int amount, int page);
        Task<IEnumerable<Service>> GetByEmployeeIdAsync(int employeeId, int amount, int page);
    }
}
