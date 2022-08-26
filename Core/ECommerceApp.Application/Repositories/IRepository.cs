using ECommerceApp.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> Table { get; }
    }
}
