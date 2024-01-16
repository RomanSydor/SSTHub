using SSTHub.Domain.ViewModels.Employee;

namespace SSTHub.Domain.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeListItemViewModel>> GetAsync(int amount, int page);
    }
}
