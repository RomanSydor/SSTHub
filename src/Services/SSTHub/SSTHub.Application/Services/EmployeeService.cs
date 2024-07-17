using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Employee;

namespace SSTHub.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
             
        public EmployeeService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EmployeeListItemViewModel>> GetByOrganizationIdAsync(int organizationId, int amount, int page)
        {  
            var employees = await _unitOfWork.EmployeeRepository.GetByOrganizationIdAsync(organizationId, amount, page);
            return _mapper.Map<IEnumerable<EmployeeListItemViewModel>>(employees);
        }

        public async Task<EmployeeDetailsViewModel> GetByIdAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
            return _mapper.Map<EmployeeDetailsViewModel>(employee);
        }

        public async Task ChangeActiveStatusAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);

            if (employee != null)
            {
                if (employee.IsActive)
                {
                    employee.IsActive = false;
                }
                else
                {
                    employee.IsActive = true;
                }

                _unitOfWork.EmployeeRepository.Update(employee);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<int> CreateAsync(EmployeeCreateViewModel createViewModel)
        {
            var employee = _mapper.Map<Employee>(createViewModel);
            employee.IsActive = true;
            employee.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.EmployeeRepository.CreateAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return employee.Id;
        }

        public async Task UpdateAsync(int id, EmployeeEditItemViewModel editItemViewModel)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);

            if (employee != null)
            {
                employee.FirstName = editItemViewModel.FirstName;
                employee.LastName = editItemViewModel.LastName;
                employee.Phone = editItemViewModel.Phone;

                _unitOfWork.EmployeeRepository.Update(employee);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
