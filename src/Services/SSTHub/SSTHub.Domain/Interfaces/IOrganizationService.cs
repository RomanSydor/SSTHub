using SSTHub.Domain.ViewModels.Organization;

namespace SSTHub.Domain.Interfaces
{
    public interface IOrganizationService
    {
        Task<int> CreateAsync(OrganizationCreateViewModel createViewModel);
        Task UpdateAsync(int id, OrganizationEditItemViewModel editItemViewModel);
        Task<OrganizationDetailsViewModel> GetByIdAsync(int id);
    }
}
