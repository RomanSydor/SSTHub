using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Infrastucture.Contexts;

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

        public void Update(Service service)
        {
            _sSTHubDbContext.Update(service);
        }

        public async Task<IEnumerable<Service>> GetByEmployeeIdAsync(int employeeId, int amount, int page)
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
                .Skip(amount * page)
                .Take(amount)
                .ToListAsync();

            return services;
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            var service = await _sSTHubDbContext
                .Services
                .Where(s => s.Id == id)
                .SingleOrDefaultAsync();

            return service;
        }

        public async Task<IEnumerable<Service>> GetByOrganizationIdAsync(int organizationId, int amount, int page)
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
                .Skip(amount * page)
                .Take(amount)
                .ToListAsync();

            return services;
        }
    }
}
