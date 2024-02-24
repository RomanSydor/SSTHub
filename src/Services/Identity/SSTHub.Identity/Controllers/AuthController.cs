using Microsoft.AspNetCore.Mvc;
using SSTHub.Identity.Models.Dtos;
using SSTHub.Identity.Models.Enums;
using SSTHub.Identity.Models.ViewModels;
using SSTHub.Identity.Services.Interfaces;

namespace SSTHub.Identity.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IHubService _hubService;
        private readonly IEmployeeService _employeeService;
        private readonly IAuthService _authService;

        public AuthController(IHubService hubService,
            IEmployeeService employeeService,
            IAuthService authService)
        {
            _hubService = hubService;
            _employeeService = employeeService;
            _authService = authService;
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin(HubAdminRegisterViewModel model)
        {
            try
            {
                var userCreate = await _authService.RegisterAdminAsync(new RegisterAdminDto
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                });

                if (!userCreate.Succeeded)
                    return StatusCode(StatusCodes.Status400BadRequest, userCreate.ErrorMessage);

                var hubId = await _hubService.CreateAsync(new HubCreateDto
                {
                    Name = model.HubName,
                });

                await _employeeService.CreateAsync(new EmployeeCreateDto
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    Role = Roles.HubAdmin,
                    HubId = hubId,
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }   
            
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
