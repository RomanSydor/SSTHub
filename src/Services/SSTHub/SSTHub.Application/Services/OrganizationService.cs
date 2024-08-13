using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Organization;

namespace SSTHub.Application.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeService _dateTimeService;

        public OrganizationService(IMapper mapper,
            IUnitOfWork unitOfWork,
            IDateTimeService dateTimeService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _dateTimeService = dateTimeService;
        }

        public async Task<int> CreateAsync(OrganizationCreateViewModel createViewModel)
        {
            var organization = _mapper.Map<Organization>(createViewModel);
            organization.IsActive = true;
            organization.CreatedAt = _dateTimeService.GetDateTimeNow();

            await _unitOfWork.OrganizationRepositiry.CreateAsync(organization);
            await _unitOfWork.SaveChangesAsync();

            return organization.Id;
        }

        public async Task<OrganizationDetailsViewModel> GetByIdAsync(int id)
        {
            var organization = await _unitOfWork.OrganizationRepositiry.GetByIdAsync(id);
            return _mapper.Map<OrganizationDetailsViewModel>(organization);
        }

        public async Task UpdateAsync(int id, OrganizationEditItemViewModel editItemViewModel)
        {
            var organization = await _unitOfWork.OrganizationRepositiry.GetByIdAsync(id);
            organization.Name = editItemViewModel.Name;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
