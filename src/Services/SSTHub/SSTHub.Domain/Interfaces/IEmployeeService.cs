using SSTHub.Domain.Entities;
using SSTHub.Domain.ViewModels.Employee;

namespace SSTHub.Domain.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeListItemViewModel>> GetAsync(int amount, int page);
        Task<EmployeeDetailsViewModel> GetByIdAsync(int id);
        Task<int> CreateAsync(EmployeeCreateViewModel createViewModel);
        Task UpdateAsync(int id, EmployeeEditItemViewModel employeeEditItemViewModel);
        Task ChangeActiveStatusAsync(int id);
    }
}
