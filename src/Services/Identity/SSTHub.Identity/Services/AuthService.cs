using Microsoft.AspNetCore.Identity;
using SSTHub.Identity.Models.Dtos;
using SSTHub.Identity.Models.Entities;
using SSTHub.Identity.Services.Interfaces;
using SSTHub.Identity.Services.ResponseDtos.Auth;

namespace SSTHub.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<EmployeeUser> _userManager;

        public AuthService(UserManager<EmployeeUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserRegisterResponseDto> UserCreateAsync(UserCreateDto dto)
        {
            var userExists = await _userManager.FindByEmailAsync(dto.Email);
            if (userExists != null)
                return new UserRegisterResponseDto { Succeeded = false, ErrorMessage = "User already exists" };

            var user = new EmployeeUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.Email,
                PhoneNumber = dto.Phone,
            };

            var addUser = await _userManager.CreateAsync(user, dto.Password);

            if (!addUser.Succeeded)
            {
                var errorList = addUser.Errors.ToList();
                var errors = string.Join(", ", errorList.Select(e => e.Description));
                return new UserRegisterResponseDto { Succeeded = false, ErrorMessage = errors };
            }

            var assignRole = await _userManager.AddToRoleAsync(user, "ORGANIZATIONADMIN");
            
            if (!assignRole.Succeeded)
            {
                var errorList = assignRole.Errors.ToList();
                var errors = string.Join(", ", errorList.Select(e => e.Description));
                return new UserRegisterResponseDto { Succeeded = false, ErrorMessage = errors };
            }

            return new UserRegisterResponseDto { Succeeded = true, ErrorMessage = "Created" };
        }
    }
}
