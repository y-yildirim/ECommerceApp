using ECommerceApp.Application.Repositories;
using ECommerceApp.Domain.Entities.Common;
using ECommerceApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerceApp.Persistence.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ECommerceAppDbContext _dbContext;

        public ReadRepository(ECommerceAppDbContext context)
        {
            _dbContext = context;
        }

        public DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        public Task<List<TEntity>> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();
            return query.ToListAsync();
        }

        public Task<List<TEntity>> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking) query = query.AsNoTracking();
            return query.ToListAsync();
        }

        public async Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true)
        {
            if (!tracking) return await Table.AsNoTracking().FirstOrDefaultAsync(method);
            return await Table.FirstOrDefaultAsync(method);
        }

        public async Task<TEntity?> GetByIdAsync(string id, bool tracking = true)
        {
            var guidId = Guid.Parse(id);
            if (!tracking) return await Table.AsNoTracking().SingleAsync(e => e.Id == guidId);
            return await Table.FindAsync(guidId);
        }
    }
}
