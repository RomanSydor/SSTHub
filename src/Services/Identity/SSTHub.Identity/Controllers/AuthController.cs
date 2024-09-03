using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SSTHub.Common.RabbitMQContracts;
using SSTHub.Identity.Models.Dtos;
using SSTHub.Identity.Models.Enums;
using SSTHub.Identity.Models.ViewModels;
using SSTHub.Identity.Services.Interfaces;

namespace SSTHub.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        private readonly IEmployeeService _employeeService;
        private readonly IAuthService _authService;
        private readonly IPublishEndpoint _publishEndpoint;

        public AuthController(IOrganizationService organizationService,
            IEmployeeService employeeService,
            IAuthService authService,
            IPublishEndpoint publishEndpoint)
        {
            _organizationService = organizationService;
            _employeeService = employeeService;
            _authService = authService;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        [Route("RegisterOrganization")]
        public async Task<IActionResult> RegisterOrganization(OrganizationAdminRegisterViewModel model)
        {
            try
            {
                var userCreate = await _authService.UserCreateAsync(new UserCreateDto
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    Role = Roles.OrganizationAdmin,
                });

                if (!userCreate.Succeeded)
                    return StatusCode(StatusCodes.Status400BadRequest, userCreate.ErrorMessage);

                var organizationId = await _organizationService.CreateAsync(new OrganizationCreateDto
                {
                    Name = model.OrganizationName,
                });

                await _employeeService.CreateAsync(new EmployeeCreateDto
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    Role = Roles.OrganizationAdmin,
                    OrganizationId = organizationId,
                });

                //TODO: add confirm email functionality   
                await _publishEndpoint.Publish<IEmailMessage>(new
                {
                    Receiver = model.Email,
                    Subject = "Account created, confirm email",
                    Body = ""
                });

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }   
        }
    }
}
