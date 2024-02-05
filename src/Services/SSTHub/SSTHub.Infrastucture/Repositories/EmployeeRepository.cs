using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Infrastucture.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SSTHubDbContext _sSTHubDbContext;

        public EmployeeRepository(SSTHubDbContext sSTHubDbContext)
        {
            _sSTHubDbContext = sSTHubDbContext;
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            _sSTHubDbContext.Update(employee);
            await _sSTHubDbContext.SaveChangesAsync();

            return true;
        }
    }
}
