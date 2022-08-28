using ECommerceApp.Domain.Entities.Common;
using System.Linq.Expressions;

namespace ECommerceApp.Application.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAll(bool tracking);
        Task<List<TEntity>> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking);
        Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking);
        Task<TEntity?> GetByIdAsync(string id, bool tracking);
    }
}
