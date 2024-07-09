using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Organization;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Application.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OrganizationService(SSTHubDbContext sSTHubDbContext,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _sSTHubDbContext = sSTHubDbContext;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAsync(OrganizationCreateViewModel createViewModel)
        {
            var organization = _mapper.Map<Organization>(createViewModel);
            organization.IsActive = true;
            organization.CreatedAt = DateTime.Now;

            await _unitOfWork.OrganizationRepositiry.CreateAsync(organization);
            await _unitOfWork.SaveChangesAsync();

            return organization.Id;
        }

        public async Task<OrganizationDetailsViewModel> GetByIdAsync(int id)
        {
            var organization = await _sSTHubDbContext.
                Organizations
                .Where(o => o.Id == id)
                .SingleOrDefaultAsync();

            return _mapper.Map<OrganizationDetailsViewModel>(organization);
        }

        public async Task UpdateAsync(int id, OrganizationEditItemViewModel editItemViewModel)
        {
            var organization = await _sSTHubDbContext.
                Organizations
                .Where(o => o.Id == id)
                .SingleOrDefaultAsync();

            if (organization != null)
            {
                organization.Name = editItemViewModel.Name;

                _unitOfWork.OrganizationRepositiry.Update(organization);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
