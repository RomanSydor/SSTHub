﻿using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Infrastructure.Contexts;

namespace SSTHub.Infrastructure.Repositories
{
    public class OrganizationRepository(SSTHubDbContext _sSTHubDbContext) : IOrganizationRepository
    {
        public async Task CreateAsync(Organization organization)
        {
            await _sSTHubDbContext.AddAsync(organization);
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
