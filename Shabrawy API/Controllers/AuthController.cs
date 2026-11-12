using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shabrawy_API.ResponseWrapper;

namespace Shabrawy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;

        public AuthController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDTO dto)
        {
            var result = await _authenticationService.RegisterAsync(dto);
            if (!result.Success)
            {
                return BadRequest(
                    APIResponse<RegisterDTO>.ErrorResponse(result.Message, result.Errors)
                );
            }

            return Ok(APIResponse<RegisterDTO>.SuccessResponse(result.Data!, result.Message));
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDTO dto)
        {
            var result = await _authenticationService.LoginAsync(dto);
            if (!result.Success)
            {
                return BadRequest(APIResponse<LoginResponseDTO>.ErrorResponse(result.Message,result.Errors));
            }
            return Ok(APIResponse<LoginResponseDTO>.SuccessResponse(result.Data!, result.Message));
        }
    }
}
