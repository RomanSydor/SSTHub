﻿using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Infrastucture.Contexts;
using System.Collections.Immutable;

namespace SSTHub.Infrastucture.Repositories
{
    public class HubRepository : IHubRepository
    {
        private readonly SSTHubDbContext _sSTHubDbContext;

        public HubRepository(SSTHubDbContext sSTHubDbContext)
        {
            _sSTHubDbContext = sSTHubDbContext;
        }
        public async Task CreateAsync(Hub hub)
        {
            await _sSTHubDbContext.AddAsync(hub);
        }

        public void Update(Hub hub)
        {
            _sSTHubDbContext.Update(hub);
        }

        public async Task<Hub> GetByIdAsync(int id)
        {
            var hub = await _sSTHubDbContext
                .Hubs
                .Where(h => h.Id == id)
                .SingleOrDefaultAsync();

            return hub;
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
