using Microsoft.AspNetCore.Mvc;
using SSTHub.Identity.Models.ViewModels;
using SSTHub.Identity.Services.Interfaces;

namespace SSTHub.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _authService) : ControllerBase
    {
        [HttpPost]
        [Route("RegisterOrganization")]
        public Task RegisterOrganization([FromBody] OrganizationRegisterViewModel model) => _authService.OrganizationRegisterAsync(model);
    }
}
