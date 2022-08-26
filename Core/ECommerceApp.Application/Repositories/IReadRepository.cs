using ECommerceApp.Domain.Entities.Common;
using System.Linq.Expressions;

namespace ECommerceApp.Application.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetWhere(Expression<Func<TEntity, bool>> method);
        Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> method);
        Task<TEntity?> GetByIdAsync(string id);
    }
}
