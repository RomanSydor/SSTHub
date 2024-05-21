using SSTHub.Domain.ViewModels.Hub;

namespace SSTHub.Domain.Interfaces
{
    public interface IHubService
    {
        Task<int> CreateAsync(HubCreateViewModel createViewModel);
        Task UpdateAsync(int id, HubEditItemViewModel editItemViewModel);
        Task ChangeActiveStatusAsync(int id);
        Task<HubDetailsViewModel> GetByIdAsync(int id);
    }
}
