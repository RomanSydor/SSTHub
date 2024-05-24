using SSTHub.Domain.ViewModels.Employee;

namespace SSTHub.Domain.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeListItemViewModel>> GetByHubIdAsync(int hubId, int amount, int page);
        Task<EmployeeDetailsViewModel> GetByIdAsync(int id);
        Task<int> CreateAsync(EmployeeCreateViewModel createViewModel);
        Task UpdateAsync(int id, EmployeeEditItemViewModel editItemViewModel);
        Task ChangeActiveStatusAsync(int id);
    }
}
