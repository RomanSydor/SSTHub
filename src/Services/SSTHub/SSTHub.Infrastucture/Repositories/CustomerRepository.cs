using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Infrastucture.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        public CustomerRepository(SSTHubDbContext sSTHubDbContext)
        {
            _sSTHubDbContext = sSTHubDbContext;
        }

        public async Task CreateAsync(Customer customer)
        {
            await _sSTHubDbContext.AddAsync(customer);
        }
    }
}
