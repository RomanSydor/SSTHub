﻿using SSTHub.Identity.Models.Dtos;
using SSTHub.Identity.Services.ResponseDtos.Auth;

namespace SSTHub.Identity.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserRegisterResponseDto> UserCreateAsync(UserCreateDto dto);
    }
}
