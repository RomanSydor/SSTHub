using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Service;
using System.Collections.Immutable;

namespace SSTHub.Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task ChangeActiveStatusAsync(int id)
        {
            var service = await _unitOfWork.ServiceRepository.GetByIdAsync(id);

            if (service != null)
            {
                if (service.IsActive)
                {
                    service.IsActive = false;
                }
                else
                {
                    service.IsActive = true;
                }

                _unitOfWork.ServiceRepository.Update(service);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<int> CreateAsync(ServiceCreateViewModel createViewModel)
        {
            var service = _mapper.Map<Service>(createViewModel);
            service.IsActive = true;
            service.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.ServiceRepository.CreateAsync(service);
            await _unitOfWork.SaveChangesAsync();

            return service.Id;
        }
        public async Task UpdateAsync(int id, ServiceEditItemViewModel editItemViewModel)
        {
            var service = await _unitOfWork.ServiceRepository.GetByIdAsync(id);

            if (service != null)
            {
                service.Price = editItemViewModel.Price;
                service.DurationInMinutes = editItemViewModel.DurationInMinutes;
                service.Name = editItemViewModel.Name;

                _unitOfWork.ServiceRepository.Update(service);
                await _unitOfWork.SaveChangesAsync();
            }
        }
        public async Task<ServiceDetailsViewModel> GetByIdAsync(int id)
        {
            var service = await _unitOfWork.ServiceRepository.GetByIdAsync(id);
            return _mapper.Map<ServiceDetailsViewModel>(service);
        }

        public async Task<ImmutableList<ServiceListItemViewModel>> GetByOrganizationIdAsync(int organizationId)
        {
            var services = await _unitOfWork.ServiceRepository.GetByOrganizationIdAsync(organizationId);
            return _mapper.Map<ImmutableList<ServiceListItemViewModel>>(services);
        }

        public async Task<ImmutableList<ServiceListItemViewModel>> GetByEmployeeIdAsync(int employeeId)
        {
            var services = await _unitOfWork.ServiceRepository.GetByEmployeeIdAsync(employeeId);
            return _mapper.Map<ImmutableList<ServiceListItemViewModel>>(services);
        }
    }
}
