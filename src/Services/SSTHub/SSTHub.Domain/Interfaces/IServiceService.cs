using SSTHub.Domain.ViewModels.Service;

namespace SSTHub.Domain.Interfaces
{
    public interface IServiceService
    {
        Task<int> CreateAsync(ServiceCreateViewModel createViewModel);
        Task UpdateAsync(int id, ServiceEditItemViewModel editItemViewModel);
        Task ChangeActiveStatusAsync(int id);
        Task<ServiceDetailsViewModel> GetByIdAsync(int id);
        Task<IEnumerable<ServiceListItemViewModel>> GetByOrganizationIdAsync(int organizationId, int amount, int page);
        Task<IEnumerable<ServiceListItemViewModel>> GetByEmployeeIdAsync(int employeeId, int amount, int page);
    }
}
