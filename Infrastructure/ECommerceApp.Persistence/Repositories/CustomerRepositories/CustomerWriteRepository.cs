using ECommerceApp.Application.Repositories.CustomerRepositories;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Persistence.Contexts;

namespace ECommerceApp.Persistence.Repositories.CustomerRepositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ECommerceAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
