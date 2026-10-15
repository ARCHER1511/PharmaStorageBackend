using Application.Auth;
using Application.DTOs;
using Application.Interfaces;
using Application.ResponseWrapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<ServiceResponse<RegisterDTO>> RegisterAsync(RegisterDTO registerDTO)
        {
            if (registerDTO.Password != registerDTO.ConfirmPassword)
            {
                return ServiceResponse<RegisterDTO>.ErrorResponse("Passwords do not match");
            }
            var user = new AppUser
            {
                UserName = registerDTO.Email,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                FullName = registerDTO.FullName,
                JobTitle = registerDTO.JobTitle,
                ContractedCompanyName = registerDTO.ContractedCompanyName,
            };
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                return ServiceResponse<RegisterDTO>.ErrorResponse(
                    "Failed to create user",
                    result.Errors.Select(e => e.Description).ToList()
                );
            }
            await _userManager.AddToRoleAsync(user, SystemRoles.Mandoob);
            return ServiceResponse<RegisterDTO>.SuccessResponse(
                registerDTO,
                "User created successfully"
            );
        }
    }
}
