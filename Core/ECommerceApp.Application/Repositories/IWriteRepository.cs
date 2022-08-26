using ECommerceApp.Domain.Entities.Common;

namespace ECommerceApp.Application.Repositories
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(List<TEntity> entity);
        bool Remove(TEntity entity);
        Task<bool> Remove(string id);
        bool RemoveRangeAsync(List<TEntity> entities);
        bool Update(TEntity entity);

        Task<int> SaveAsync();
    }
}
