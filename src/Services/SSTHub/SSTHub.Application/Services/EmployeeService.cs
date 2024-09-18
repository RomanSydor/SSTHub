using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Employee;
using System.Collections.Immutable;

namespace SSTHub.Application.Services
{
    public class EmployeeService(IMapper _mapper,
        IUnitOfWork _unitOfWork,
        IDateTimeService _dateTimeService) : IEmployeeService
    {
        public async Task<ImmutableList<EmployeeListItemViewModel>> GetByOrganizationIdAsync(int organizationId)
        {  
            var employees = await _unitOfWork.EmployeeRepository.GetByOrganizationIdAsync(organizationId);
            return _mapper.Map<ImmutableList<EmployeeListItemViewModel>>(employees);
        }

        public async Task<EmployeeDetailsViewModel> GetByIdAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            return _mapper.Map<EmployeeDetailsViewModel>(employee);
        }

        public async Task ChangeActiveStatusAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            employee.IsActive = !employee.IsActive;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(EmployeeCreateViewModel createViewModel)
        {
            var employee = _mapper.Map<Employee>(createViewModel);
            employee.IsActive = true;
            employee.CreatedAt = _dateTimeService.GetDateTimeNow();

            await _unitOfWork.EmployeeRepository.CreateAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return employee.Id;
        }

        public async Task UpdateAsync(int id, EmployeeEditItemViewModel editItemViewModel)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            employee.FirstName = editItemViewModel.FirstName;
            employee.LastName = editItemViewModel.LastName;
            employee.Phone = editItemViewModel.Phone;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
