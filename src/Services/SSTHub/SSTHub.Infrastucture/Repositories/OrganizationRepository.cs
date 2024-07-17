using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Infrastucture.Repositories
{
    public class OrganizationRepository : IOrganizationRepositiry
    {
        private readonly SSTHubDbContext _sSTHubDbContext;

        public OrganizationRepository(SSTHubDbContext sSTHubDbContext)
        {
            _sSTHubDbContext = sSTHubDbContext;
        }

        public async Task CreateAsync(Organization organization)
        {
            await _sSTHubDbContext.AddAsync(organization);
        }

        public void Update(Organization organization)
        {
            _sSTHubDbContext.Update(organization);
        }

        public async Task<Organization> GetByIdAsync(int id)
        {
            var organization = await _sSTHubDbContext.
                Organizations
                .Where(o => o.Id == id)
                .SingleOrDefaultAsync();

            return organization;
        }
    }
}
