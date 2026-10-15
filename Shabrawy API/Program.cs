using Shabrawy_API.Extensions;

namespace Shabrawy_API
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            // Swagger generator
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Add services from other layers (Infrastructure, Application, etc.)
            builder.Services.AddCustomIdentityServices(builder.Configuration);
            builder.Services.AddScopedCollection();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });


            var app = builder.Build();

            //Seed Data on Startup
            using (var scope = app.Services.CreateScope())
            {
                await IdentitySeeder.SeedRolesAsync(scope.ServiceProvider);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthentication(); // Validate JWT and create User principal

            app.UseAuthorization(); // Check [Authorize]

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
