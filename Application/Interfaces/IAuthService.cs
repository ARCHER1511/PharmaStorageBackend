using Application.DTOs;
using Application.ResponseWrapper;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<RegisterDTO>> RegisterAsync(RegisterDTO registerDTO);
        Task<ServiceResponse<LoginResponseDTO>> LoginAsync(LoginDTO loginDTO);
        Task<ServiceResponse<bool>> LogoutAsync();
    }
}
