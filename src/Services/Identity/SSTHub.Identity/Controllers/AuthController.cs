using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SSTHub.Identity.Models.Entities;
using SSTHub.Identity.Models.ViewModels;

namespace SSTHub.Identity.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<EmployeeUser> _userManager;

        public AuthController(UserManager<EmployeeUser> userManager)
        {
            _userManager = userManager;
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

            // TODO: Add call of SSTHub API to add User to Employees table
            // TODO: Add call of SSTHub API to add Hub to Hubs table

            return Ok(new { Status = "Success", Message = "User created successfully!" });
        }
    }
}
