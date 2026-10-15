using Domain.Enums;
using Microsoft.AspNetCore.Identity;
namespace Domain.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public AppUser()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string FullName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        //public CompanyType companyType { get; set; } = CompanyType.Default;
        public string? ContractedCompanyName { get; set; } = string.Empty;
        public AccountStatus status { get; set; } = AccountStatus.Pending;
        public string NationalIdFrontImagePath { get; set; } = string.Empty;
        public string NationalIdBackImagePath { get; set; } = string.Empty;
        public string AuthorizationLetterImagePath { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovedAt { get; set; }
        public string? ApprovedBy { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
