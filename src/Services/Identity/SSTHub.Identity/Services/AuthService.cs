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

        public async Task<RegisterAdminResponseDto> RegisterAdminAsync(RegisterAdminDto dto)
        {
            var userExists = await _userManager.FindByEmailAsync(dto.Email);
            if (userExists != null)
                return new RegisterAdminResponseDto { Succeeded = false, ErrorMessage = "User already exists" };

            var user = new EmployeeUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.Email,
            };

            var addUser = await _userManager.CreateAsync(user, dto.Password);

            if (!addUser.Succeeded)
            {
                var errorList = addUser.Errors.ToList();
                var errors = string.Join(", ", errorList.Select(e => e.Description));
                return new RegisterAdminResponseDto { Succeeded = false, ErrorMessage = errors };
            }

            var assignRole = await _userManager.AddToRoleAsync(user, "HUBADMIN");
            if (!assignRole.Succeeded)
            {
                var errorList = assignRole.Errors.ToList();
                var errors = string.Join(", ", errorList.Select(e => e.Description));
                return new RegisterAdminResponseDto { Succeeded = false, ErrorMessage = errors };
            }

            return new RegisterAdminResponseDto { Succeeded = true, ErrorMessage = "Created" };
        }
    }
}
