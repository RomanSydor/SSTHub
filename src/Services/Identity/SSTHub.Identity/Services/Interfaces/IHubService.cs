using SSTHub.Identity.Models.Dtos;

namespace SSTHub.Identity.Services.Interfaces
{
    public interface IHubService
    {
        Task<int> CreateAsync(HubCreateDto createDto);

    }
}
