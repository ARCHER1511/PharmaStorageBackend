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
            var existingUser = await _userManager.FindByEmailAsync(registerDTO.Email);

            if (existingUser != null)
            {
                return ServiceResponse<RegisterDTO>.ErrorResponse("Email already exists");
            }
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

        public async Task<ServiceResponse<LoginResponseDTO>> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null)
            {
                return ServiceResponse<LoginResponseDTO>.ErrorResponse("Invalid email or password");
            }
            //if (!user.EmailConfirmed)
            //{
            //    return ServiceResponse<LoginResponseDTO>.ErrorResponse(
            //        "Please verify your email first");
            //}
            var signInResult = await _signInManager.CheckPasswordSignInAsync(
                user,
                loginDTO.Password,
                lockoutOnFailure: true
            );

            //if (signInResult.IsLockedOut)
            //{
            //    return ServiceResponse<LoginResponseDTO>.ErrorResponse("Account is locked");
            //}

            //if (signInResult.IsNotAllowed)
            //{
            //    return ServiceResponse<LoginResponseDTO>.ErrorResponse(
            //        "Account is not allowed to login"
            //    );
            //}

            if (!signInResult.Succeeded)
            {
                return ServiceResponse<LoginResponseDTO>.ErrorResponse("Invalid email or password");
            }

            var roles = await _userManager.GetRolesAsync(user);

            var token = await _tokenService.CreateToken(user);

            var response = new LoginResponseDTO
            {
                AccessToken = token,
                Email = user.Email!,
                FullName = user.FullName,
                Roles = roles,
            };

            return ServiceResponse<LoginResponseDTO>.SuccessResponse(response, "Login successful");
        }

        public async Task<ServiceResponse<bool>> LogoutAsync()
        {
            await _signInManager.SignOutAsync();

            return ServiceResponse<bool>.SuccessResponse(true, "Logged out successfully");
        }
    }
}
