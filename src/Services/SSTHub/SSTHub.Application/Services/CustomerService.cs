using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Customer;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(SSTHubDbContext sSTHubDbContext, IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _sSTHubDbContext = sSTHubDbContext;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(CustomerCreateViewModel createViewModel)
        {
            var customer = _mapper.Map<Customer>(createViewModel);
            customer.CreatedAt = DateTime.Now; 

            await _unitOfWork.CustomerRepository.CreateAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            return customer.Id;
        }

        public async Task<IEnumerable<CustomerListItemViewModel>> GetByHubIdAsync(int hubId, int amount, int page)
        {
            var customerIds = await _sSTHubDbContext
                .Events
                .Where(e => e.HubId == hubId)
                .Select(e => e.CustomerId)
                .ToListAsync();

            var customers = await _sSTHubDbContext
                .Customers
                .Where(c => customerIds.Contains(c.Id))
                .Skip(amount * page)
                .Take(amount)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CustomerListItemViewModel>>(customers);
        }

        public async Task<IEnumerable<CustomerListItemViewModel>> GetByOrganizationIdAsync(int organizationId, int amount, int page)
        {
            var hubIds = await _sSTHubDbContext
                .Hubs
                .Where(h => h.OrganizationId == organizationId)
                .Select(h => h.Id)
                .ToListAsync();

            var customerIds = await _sSTHubDbContext
                .Events
                .Where(e => hubIds.Contains(e.HubId))
                .Select(e => e.CustomerId)
                .ToListAsync();

            var customers = await _sSTHubDbContext
                .Customers
                .Where(c => customerIds.Contains(c.Id))
                .Skip(amount * page)
                .Take(amount)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CustomerListItemViewModel>>(customers);
        }
    }
}
