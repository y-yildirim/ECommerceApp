using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Persistence.Contexts
{
    public class ECommerceAppDbContext : DbContext
    {
        public ECommerceAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                _ = entry.State switch
                {
                    EntityState.Added => entry.Entity.CreatedAt = DateTime.UtcNow,
                    EntityState.Modified => entry.Entity.UpdatedAt = DateTime.UtcNow,
                    _ => throw new InvalidOperationException(nameof(entry.State))
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
