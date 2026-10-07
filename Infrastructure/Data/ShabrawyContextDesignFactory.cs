using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    public class ShabrawyContextDesignFactory : IDesignTimeDbContextFactory<ShabrawyContext>
    {
        public ShabrawyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShabrawyContext>();

            // Hardcoded connection string specifically used for design-time (migrations, scaffolding)
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ShabrawyAPI;Trusted_Connection=true;TrustServerCertificate=True");

            return new ShabrawyContext(optionsBuilder.Options);
        }
    }
}