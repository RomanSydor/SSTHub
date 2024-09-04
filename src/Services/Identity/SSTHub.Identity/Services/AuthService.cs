using AutoMapper;
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
    public class AuthService : IAuthService
    {
        private readonly UserManager<EmployeeUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IOrganizationService _organizationService;
        private readonly IEmployeeService _employeeService;
        private readonly IPublishEndpoint _publishEndpoint;

        public AuthService(UserManager<EmployeeUser> userManager,
            IMapper mapper,
            IOrganizationService organizationService,
            IEmployeeService employeeService,
            IPublishEndpoint publishEndpoint)
        {
            _userManager = userManager;
            _mapper = mapper;
            _organizationService = organizationService;
            _employeeService = employeeService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task OrganizationRegisterAsync(OrganizationRegisterViewModel model)
        {
            var user = _mapper.Map<EmployeeUser>(model);
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
