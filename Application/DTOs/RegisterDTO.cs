using Microsoft.AspNetCore.Http;

namespace Application.DTOs
{
    public class RegisterDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        //public CompanyType companyType { get; set; } = CompanyType.Default;
        public string? ContractedCompanyName { get; set; } = string.Empty;
        public string NationalIdNumber { get; set; } = string.Empty;
        public IFormFile NationalIdFrontImage { get; set; } = null!;
        public IFormFile NationalIdBackImage { get; set; } = null!;
        public IFormFile AuthorizationLetterFile { get; set; } = null!;
    }
}
