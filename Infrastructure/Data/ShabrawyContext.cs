using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ShabrawyContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ShabrawyContext(DbContextOptions<ShabrawyContext> options)
            : base(options) { }

        //DbSets for your entities

        //On Model Creating method to configure the model
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().ToTable("Users", "Identity");
            builder.Entity<AppRole>().ToTable("Roles", "Identity");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Identity");

            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Identity");

            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Identity");

            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Identity");

            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Identity");
        }
    }
}
