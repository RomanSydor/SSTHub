using SSTHub.Identity.Models.Dtos;

namespace SSTHub.Identity.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task<int> CreateAsync(OrganizationCreateDto createDto);

    }
}
