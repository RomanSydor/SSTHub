using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SSTHub.Identity.Models.Dtos;
using SSTHub.Identity.Models.Entities;
using SSTHub.Identity.Models.ViewModels;
using SSTHub.Identity.Services.Interfaces;

namespace SSTHub.Identity.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<EmployeeUser> _userManager;
        private readonly IHubService _hubService;
        private readonly IEmployeeService _employeeService;

        public AuthController(UserManager<EmployeeUser> userManager,
            IHubService hubService,
            IEmployeeService employeeService)
        {
            _userManager = userManager;
            _hubService = hubService;
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin(HubAdminRegisterViewModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User already exists!" });

            var user = new EmployeeUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
            };

            var addUser = await _userManager.CreateAsync(user, model.Password);
            if (!addUser.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = addUser.Errors });

            var assignRole = await _userManager.AddToRoleAsync(user, "HUBADMIN");
            if (!assignRole.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Role assign failed!" });

            int hubId;

            try
            {
                var hub = new HubCreateDto
                {
                    Name = model.HubName,
                };

                hubId = await _hubService.CreateAsync(hub);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", e.Message });
            }

            try
            {
                var employee = new EmployeeCreateDto
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    HubId = hubId,
                };

                await _employeeService.CreateAsync(employee);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", e.Message });
            }

            return Ok(new { Status = "Success", Message = "User created successfully!" });
        }
    }
}
