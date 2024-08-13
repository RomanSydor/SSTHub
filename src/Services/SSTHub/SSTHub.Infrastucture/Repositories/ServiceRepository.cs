using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Infrastucture.Contexts;
using System.Collections.Immutable;

namespace SSTHub.Infrastucture.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly SSTHubDbContext _sSTHubDbContext;

        public ServiceRepository(SSTHubDbContext sSTHubDbContext)
        {
            _sSTHubDbContext = sSTHubDbContext;
        }

        public async Task CreateAsync(Service service)
        {
            await _sSTHubDbContext.AddAsync(service);
        }

        public async Task<ImmutableList<Service>> GetByEmployeeIdAsync(int employeeId)
        {
            var serviceIds = await _sSTHubDbContext.Set<Dictionary<string, object>>("EmployeeService")
                .Select(es => new
                {
                    EmployeesId = (int)es["EmployeesId"],
                    ServicesId = (int)es["ServicesId"],
                })
                .Where(es => es.EmployeesId == employeeId)
                .Select(e => e.ServicesId)
                .ToListAsync();

            var services = await _sSTHubDbContext
                .Services
                .Where(s => serviceIds.Contains(s.Id))
                .ToListAsync();

            return services.ToImmutableList();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            var service = await _sSTHubDbContext
                .Services
                .Where(s => s.Id == id)
                .SingleOrDefaultAsync();

            return service;
        }

        public async Task<ImmutableList<Service>> GetByOrganizationIdAsync(int organizationId)
        {
            var employeeIds = await _sSTHubDbContext
                .Employees
                .Where(e => e.OrganizationId == organizationId)
                .Select(e => e.Id)
                .ToListAsync();

            var serviceIds = await _sSTHubDbContext.Set<Dictionary<string, object>>("EmployeeService")
                .Select(es => new
                {
                    EmployeesId = (int)es["EmployeesId"],
                    ServicesId = (int)es["ServicesId"],
                })
                .Where(es => employeeIds.Contains(es.EmployeesId))
                .Select(e => e.ServicesId)
                .ToListAsync();

            var services = await _sSTHubDbContext
                .Services
                .Where(s => serviceIds.Contains(s.Id))
                .ToListAsync();

            return services.ToImmutableList();
        }
    }
}
