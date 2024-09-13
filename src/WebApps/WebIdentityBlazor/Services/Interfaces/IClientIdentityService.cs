using WebIdentityBlazor.Models;

namespace WebIdentityBlazor.Services.Interfaces
{
    public interface IClientIdentityService
    {
        Task OrganizationRegisterAsync(OrganizationRegisterViewModel model);
    }
}
