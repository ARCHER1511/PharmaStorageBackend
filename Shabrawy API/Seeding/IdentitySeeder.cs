using Application.Auth;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

public static class IdentitySeeder
{
    public static async Task SeedRolesAsync(
        IServiceProvider services)
    {
        var roleManager =
            services.GetRequiredService<RoleManager<AppRole>>();

        if (!await roleManager.RoleExistsAsync(SystemRoles.Admin))
        {
            await roleManager.CreateAsync(new AppRole
            {
                Name = SystemRoles.Admin,
                ArabicName = "أدمن"
            });
        }

        if (!await roleManager.RoleExistsAsync(SystemRoles.Mandoob))
        {
            await roleManager.CreateAsync(new AppRole
            {
                Name = SystemRoles.Mandoob,
                ArabicName = "مندوب"
            });
        }

        if (!await roleManager.RoleExistsAsync(SystemRoles.PurchasingRepresentative))
        {
            await roleManager.CreateAsync(new AppRole
            {
                Name = SystemRoles.PurchasingRepresentative,
                ArabicName = "ممثل قسم المشتريات"
            });
        }
    }
}