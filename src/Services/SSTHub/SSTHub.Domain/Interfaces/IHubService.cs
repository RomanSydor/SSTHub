using SSTHub.Domain.ViewModels.Hub;

namespace SSTHub.Domain.Interfaces
{
    public interface IHubService
    {
        Task<int> CreateAsync(HubCreateViewModel createViewModel);

    }
}
