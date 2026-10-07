using Microsoft.AspNetCore.Identity;
namespace Domain.Entities
{
    public class AppRole : IdentityRole<string>
    {
        public AppRole()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string ArabicName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
