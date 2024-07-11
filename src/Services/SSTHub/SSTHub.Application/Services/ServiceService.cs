using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Service;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceService(SSTHubDbContext sSTHubDbContext,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _sSTHubDbContext = sSTHubDbContext;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task ChangeActiveStatusAsync(int id)
        {
            var service = await _sSTHubDbContext
               .Services
               .Where(s => s.Id == id)
               .SingleOrDefaultAsync();

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
            var service = await _sSTHubDbContext
                .Services
                .Where(s => s.Id == id)
                .SingleOrDefaultAsync();

            if (service != null)
            {
                service.Price = editItemViewModel.Price;
                service.DurationInMinutes = editItemViewModel.DurationInMinutes;
                service.Name = editItemViewModel.Name;

                _sSTHubDbContext.Services.Update(service);
                await _unitOfWork.SaveChangesAsync();
            }
        }
        public async Task<ServiceDetailsViewModel> GetByIdAsync(int id)
        {
            var service = await _sSTHubDbContext
                .Services
                .Where(s => s.Id == id)
                .SingleOrDefaultAsync();

            return _mapper.Map<ServiceDetailsViewModel>(service);
        }

        public async Task<IEnumerable<ServiceListItemViewModel>> GetByOrganizationIdAsync(int organizationId, int amount, int page)
        {
            var employeeIds = await _sSTHubDbContext
                .Employees
                .Where(e => e.OrganizationId == organizationId)
                .Select(e => e.Id)
                .ToListAsync();

            var serviceIds = await _sSTHubDbContext.Set<Dictionary<string, object>>("EmployeeService")
                .Select(es => new
                {
                    EmployeesId = (int)es["EmployeesId"],
                    ServicesId = (int)es["ServicesId"],
                })
                .Where(es => employeeIds.Contains(es.EmployeesId))
                .Select(e => e.ServicesId)
                .ToListAsync();

            var services = await _sSTHubDbContext
                .Services
                .Where(s => serviceIds.Contains(s.Id))
                .Skip(amount * page)
                .Take(amount)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ServiceListItemViewModel>>(services);
        }

        public async Task<IEnumerable<ServiceListItemViewModel>> GetByEmployeeIdAsync(int employeeId, int amount, int page)
        {
            var serviceIds = await _sSTHubDbContext.Set<Dictionary<string, object>>("EmployeeService")
                .Select(es => new
                {
                    EmployeesId = (int)es["EmployeesId"],
                    ServicesId = (int)es["ServicesId"],
                })
                .Where(es => es.EmployeesId == employeeId)
                .Select(e => e.ServicesId)
                .ToListAsync();

            var services = await _sSTHubDbContext
                .Services
                .Where(s => serviceIds.Contains(s.Id))
                .Skip(amount * page)
                .Take(amount)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ServiceListItemViewModel>>(services);
        }
    }
}
