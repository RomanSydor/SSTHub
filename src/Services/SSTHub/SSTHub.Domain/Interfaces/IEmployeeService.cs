using SSTHub.Domain.ViewModels.Employee;
using System.Collections.Immutable;

namespace SSTHub.Domain.Interfaces
{
    public interface IEmployeeService
    {
        Task<ImmutableList<EmployeeListItemViewModel>> GetByOrganizationIdAsync(int organizationId);
        Task<EmployeeDetailsViewModel> GetByIdAsync(int id);
        Task<int> CreateAsync(EmployeeCreateViewModel createViewModel);
        Task UpdateAsync(int id, EmployeeEditItemViewModel editItemViewModel);
        Task ChangeActiveStatusAsync(int id);
    }
}
