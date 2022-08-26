using ECommerceApp.Application.Repositories;
using ECommerceApp.Domain.Entities.Common;
using ECommerceApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerceApp.Persistence.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        ECommerceAppDbContext _dbContext;

        public WriteRepository(ECommerceAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        public async Task<bool> AddAsync(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Remove(TEntity entity)
        {
            return Table.Remove(entity).State == EntityState.Deleted;
        }

        public async Task<bool> Remove(string id)
        {
            var entity = await Table.FindAsync(id);
            return entity is not null ? Table.Remove(entity).State == EntityState.Deleted : false;
        }

        public bool RemoveRangeAsync(List<TEntity> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public bool Update(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();

    }
}
