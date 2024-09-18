using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Infrastructure.Contexts;
using System.Collections.Immutable;

namespace SSTHub.Infrastructure.Repositories
{
    public class EmployeeRepository(SSTHubDbContext _sSTHubDbContext) : IEmployeeRepository
    {
        public async Task CreateAsync(Employee employee)
        {
            await _sSTHubDbContext.AddAsync(employee);
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
