using Application.DTOs;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> RegisterAsync(RegisterDTO registerDTO);
    }
}
