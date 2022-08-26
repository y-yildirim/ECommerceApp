using ECommerceApp.Application.Repositories.OrderRepositories;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Persistence.Contexts;

namespace ECommerceApp.Persistence.Repositories.OrderRepositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(ECommerceAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
