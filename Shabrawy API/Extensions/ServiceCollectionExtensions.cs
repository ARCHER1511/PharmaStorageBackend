using Application.Interfaces;
using Application.Services;
namespace Shabrawy_API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddScopedCollection(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
