using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using Application.Interfaces;
using Application.DTOs;
using Application.ResponseWrapper;

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthenticationService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> RegisterAsync(RegisterDTO registerDTO)
        {
            if (registerDTO.Password != registerDTO.ConfirmPassword)
            {
                return ServiceResponseFactory.BadRequest<RegisterDTO>("Passwords do not match").Message!;
            }
            return "";
        }
    }
}
