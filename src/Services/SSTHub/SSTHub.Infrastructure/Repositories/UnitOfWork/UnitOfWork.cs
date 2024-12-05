using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.Contexts;
using SSTHub.Domain.Interfaces.UnitOfWork;

namespace SSTHub.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWork(ISSTHubDbContext _sSTHubDbContext) : IUnitOfWork
    {
        IEmployeeRepository? _employeeRepository;
        IHubRepository? _hubRepository;
        IServiceRepository? _serviceRepository;
        IEventRepository? _eventRepository;
        ICustomerRepository? _customerRepository;
        IOrganizationRepository? _organizationRepositiry;

        public IEmployeeRepository EmployeeRepository 
        {
            get { return _employeeRepository ??= new EmployeeRepository(_sSTHubDbContext); }
        }

        public IHubRepository HubRepository
        {
            get { return _hubRepository ??= new HubRepository(_sSTHubDbContext); }
        }

        public IServiceRepository ServiceRepository
        {
            get { return _serviceRepository ??= new ServiceRepository(_sSTHubDbContext); }
        }

        public IEventRepository EventRepository
        {
            get { return _eventRepository ??= new EventRepository(_sSTHubDbContext); }
        }

        public ICustomerRepository CustomerRepository
        {
            get { return _customerRepository ??= new CustomerRepository(_sSTHubDbContext); }
        }

        public IOrganizationRepository OrganizationRepository
        {
            get { return _organizationRepositiry ??= new OrganizationRepository(_sSTHubDbContext); }
        }

        public async Task SaveChangesAsync()
        {
            await _sSTHubDbContext.SaveChangesAsync();
        }
    }
}
