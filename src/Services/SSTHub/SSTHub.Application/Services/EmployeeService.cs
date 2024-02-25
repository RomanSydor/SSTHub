using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Employee;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
             
        public EmployeeService(SSTHubDbContext sSTHubDbContext,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _sSTHubDbContext = sSTHubDbContext;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EmployeeListItemViewModel>> GetAsync(int amount, int page)
        {
            var employees = await _sSTHubDbContext
                .Employees
                .Skip(amount * page)
                .Take(amount)
                .ToListAsync();

            return _mapper.Map<IEnumerable<EmployeeListItemViewModel>>(employees);
        }

        public async Task<EmployeeDetailsViewModel> GetByIdAsync(int id)
        {
            var employee = await _sSTHubDbContext
                .Employees
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();

            return _mapper.Map<EmployeeDetailsViewModel>(employee);
        }

        public async Task ChangeActiveStatusAsync(int id)
        {
            var employee = await _sSTHubDbContext
                .Employees
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();

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

            var employeeId = await _unitOfWork.EmployeeRepository.CreateAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return employeeId;
        }

        public async Task UpdateAsync(int id, EmployeeEditItemViewModel employeeEditItemViewModel)
        {
            var employee = await _sSTHubDbContext
                .Employees
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();

            if (employee != null)
            {
                employee.FirstName = employeeEditItemViewModel.FirstName;
                employee.LastName = employeeEditItemViewModel.LastName;
                employee.Phone = employeeEditItemViewModel.Phone;

                _unitOfWork.EmployeeRepository.Update(employee);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
