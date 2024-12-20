﻿using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.Contexts;
using System.Collections.Immutable;

namespace SSTHub.Infrastructure.Repositories
{
    public class HubRepository(ISSTHubDbContext _sSTHubDbContext) : IHubRepository
    {
        public async Task CreateAsync(Hub hub)
        {
            await _sSTHubDbContext.AddAsync(hub);
        }

        public async Task<Hub> GetByIdAsync(int id)
        {
            var hub = await _sSTHubDbContext
                .Hubs
                .Where(h => h.Id == id)
                .SingleOrDefaultAsync();

            return hub!;
        }

        public async Task<ImmutableList<Hub>> GetByOrganizationIdAsync(int organizationId)
        {
            var hubs = await _sSTHubDbContext
                .Hubs
                .Where(h => h.OrganizationId == organizationId)
                .ToListAsync();

            return hubs.ToImmutableList();
        }
    }
}
