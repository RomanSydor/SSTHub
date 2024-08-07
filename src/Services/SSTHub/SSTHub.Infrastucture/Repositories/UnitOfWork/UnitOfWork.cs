﻿using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Infrastucture.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SSTHubDbContext _sSTHubDbContext;

        IEmployeeRepository? _employeeRepository;
        IHubRepository? _hubRepository;
        IServiceRepository? _serviceRepository;
        IEventRepository? _eventRepository;
        ICustomerRepository? _customerRepository;
        IOrganizationRepositiry? _organizationRepositiry;

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

        public IEventRepository EventRepository
        {
            get { return _eventRepository ??= new EventRepository(_sSTHubDbContext); }
        }

        public ICustomerRepository CustomerRepository
        {
            get { return _customerRepository ??= new CustomerRepository(_sSTHubDbContext); }
        }

        public IOrganizationRepositiry OrganizationRepositiry
        {
            get { return _organizationRepositiry ??= new OrganizationRepository(_sSTHubDbContext); }
        }

        public async Task SaveChangesAsync()
        {
            await _sSTHubDbContext.SaveChangesAsync();
        }
    }
}
