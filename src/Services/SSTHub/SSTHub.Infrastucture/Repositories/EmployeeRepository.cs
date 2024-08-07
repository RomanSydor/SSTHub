using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Infrastucture.Contexts;
using System.Collections.Immutable;

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

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee = await _sSTHubDbContext
                .Employees
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();

            return employee;
        }

        public async Task<ImmutableList<Employee>> GetByOrganizationIdAsync(int organizationId)
        {
            var employees = await _sSTHubDbContext
                .Employees
                .Where(e => e.OrganizationId == organizationId)
                .ToListAsync();

            return employees.ToImmutableList();
        }
    }
}
