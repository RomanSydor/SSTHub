using SSTHub.Domain.ViewModels.Service;
using System.Collections.Immutable;

namespace SSTHub.Domain.Interfaces
{
    public interface IServiceService
    {
        Task<int> CreateAsync(ServiceCreateViewModel createViewModel);
        Task UpdateAsync(int id, ServiceEditItemViewModel editItemViewModel);
        Task ChangeActiveStatusAsync(int id);
        Task<ServiceDetailsViewModel> GetByIdAsync(int id);
        Task<ImmutableList<ServiceListItemViewModel>> GetByOrganizationIdAsync(int organizationId);
        Task<ImmutableList<ServiceListItemViewModel>> GetByEmployeeIdAsync(int employeeId);
    }
}
