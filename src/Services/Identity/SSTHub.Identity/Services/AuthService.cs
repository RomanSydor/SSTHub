using MassTransit;
using Microsoft.AspNetCore.Identity;
using SSTHub.Common.RabbitMQContracts;
using SSTHub.Identity.Models.Dtos;
using SSTHub.Identity.Models.Entities;
using SSTHub.Identity.Models.Enums;
using SSTHub.Identity.Models.ViewModels;
using SSTHub.Identity.Services.Interfaces;

namespace SSTHub.Identity.Services
{
    public class AuthService(UserManager<EmployeeUser> _userManager,
        IOrganizationService _organizationService,
        IEmployeeService _employeeService,
        IPublishEndpoint _publishEndpoint) : IAuthService
    {
        public async Task OrganizationRegisterAsync(OrganizationRegisterViewModel model)
        {
            var user = new EmployeeUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.Phone,
            };
            await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, "ORGANIZATIONADMIN");
            
            var organizationId = await _organizationService.CreateAsync( new OrganizationCreateDto
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
        }
    }
}
