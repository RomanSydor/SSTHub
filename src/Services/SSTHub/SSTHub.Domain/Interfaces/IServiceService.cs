using SSTHub.Domain.ViewModels.Service;

namespace SSTHub.Domain.Interfaces
{
    public interface IServiceService
    {
        Task<int> CreateAsync(ServiceCreateViewModel createViewModel);
        Task UpdateAsync(int id, ServiceEditItemViewModel editItemViewModel);
        Task ChangeActiveStatusAsync(int id);
        Task<IEnumerable<ServiceListItemViewModel>> GetByHubId(int hubId);
        Task<IEnumerable<ServiceListItemViewModel>> GetByEmployeeId(int employeeId);

    }
}
