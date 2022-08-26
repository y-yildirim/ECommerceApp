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

        public Task<List<TEntity>> GetAll() => Table.ToListAsync();

        public Task<List<TEntity>> GetWhere(Expression<Func<TEntity, bool>> method) => Table.Where(method).ToListAsync();

        public async Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> method) => await Table.FirstOrDefaultAsync(method);

        public async Task<TEntity?> GetByIdAsync(string id) => await Table.FindAsync(id);
    }
}
