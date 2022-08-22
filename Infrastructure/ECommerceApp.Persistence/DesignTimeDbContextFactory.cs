using ECommerceApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ECommerceApp.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceAppDbContext>
    {
        public ECommerceAppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ECommerceAppDbContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(optionsBuilder.Options);
        }
    }
}
