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

        public async Task CreateAsync(Employee employee)
        {
            await _sSTHubDbContext.AddAsync(employee);
        }

        public void Update(Employee employee)
        {
            _sSTHubDbContext.Update(employee);
        }
    }
}
