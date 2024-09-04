using SSTHub.Identity.Models.ViewModels;

namespace SSTHub.Identity.Services.Interfaces
{
    public interface IAuthService
    {
        Task OrganizationRegisterAsync(OrganizationRegisterViewModel model);
    }
}
