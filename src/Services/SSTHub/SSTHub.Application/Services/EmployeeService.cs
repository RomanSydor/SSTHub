using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Employee;
using SSTHub.Infrastucture.Contexts;

namespace SSTHub.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly SSTHubDbContext _sSTHubDbContext;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
             
        public EmployeeService(SSTHubDbContext sSTHubDbContext,
            IMapper mapper,
            IEmployeeRepository employeeRepository)
        {
            _sSTHubDbContext = sSTHubDbContext;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
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

        public async Task<bool> ChangeActiveStatusAsync(int id)
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
                return await _employeeRepository.UpdateAsync(employee);
            }

            return false;
        }

        public async Task<bool> UpdateAsync(int id, EmployeeEditItemViewModel employeeEditItemViewModel)
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
                employee.Position = employeeEditItemViewModel.Position;

                return await _employeeRepository.UpdateAsync(employee);
            }

            return false;
        }
    }
}
