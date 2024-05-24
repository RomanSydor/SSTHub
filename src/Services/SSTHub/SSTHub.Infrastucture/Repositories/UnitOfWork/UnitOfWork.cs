using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Infrastucture.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SSTHubDbContext _sSTHubDbContext;

        IEmployeeRepository _employeeRepository;
        IHubRepository _hubRepository;
        IServiceRepository _serviceRepository;

        public UnitOfWork(SSTHubDbContext sSTHubDbContext)
        {
            _sSTHubDbContext = sSTHubDbContext;
        }

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

        public async Task SaveChangesAsync()
        {
            await _sSTHubDbContext.SaveChangesAsync();
        }
    }
}
