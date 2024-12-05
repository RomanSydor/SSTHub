using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.Contexts;
using System.Collections.Immutable;

namespace SSTHub.Infrastructure.Repositories
{
    public class CustomerRepository(ISSTHubDbContext _sSTHubDbContext) : ICustomerRepository
    {
        public async Task CreateAsync(Customer customer)
        {
            await _sSTHubDbContext.AddAsync(customer);
        }

        public async Task<ImmutableList<Customer>> GetByHubIdAsync(int hubId)
        {
            var customerIds = await _sSTHubDbContext
                .Events
                .Where(e => e.HubId == hubId)
                .Select(e => e.CustomerId)
                .ToListAsync();

            var customers = await _sSTHubDbContext
                .Customers
                .Where(c => customerIds.Contains(c.Id))
                .ToListAsync();

            return customers.ToImmutableList();
        }

        public async Task<ImmutableList<Customer>> GetByOrganizationIdAsync(int organizationId)
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
                .ToListAsync();

            return customers.ToImmutableList();
        }
    }
}
