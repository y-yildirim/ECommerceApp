using ECommerceApp.Application.Repositories.ProductRepositories;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Persistence.Contexts;

namespace ECommerceApp.Persistence.Repositories.ProductRepositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ECommerceAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
