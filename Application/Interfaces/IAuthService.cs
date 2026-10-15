using Application.DTOs;
using Application.ResponseWrapper;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<RegisterDTO>> RegisterAsync(RegisterDTO registerDTO);
    }
}
