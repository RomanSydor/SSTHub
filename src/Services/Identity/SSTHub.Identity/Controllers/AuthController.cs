using Microsoft.AspNetCore.Mvc;
using SSTHub.Identity.Models.ViewModels;
using SSTHub.Identity.Services.Interfaces;

namespace SSTHub.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("RegisterOrganization")]
        public async Task RegisterOrganization([FromBody] OrganizationRegisterViewModel model)
        {
            await _authService.OrganizationRegisterAsync(model);
        }
    }
}
