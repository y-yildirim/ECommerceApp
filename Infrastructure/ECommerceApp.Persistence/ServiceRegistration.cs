using ECommerceApp.Application.Repositories.CustomerRepositories;
using ECommerceApp.Application.Repositories.OrderRepositories;
using ECommerceApp.Application.Repositories.ProductRepositories;
using ECommerceApp.Persistence.Contexts;
using ECommerceApp.Persistence.Repositories.CustomerRepositories;
using ECommerceApp.Persistence.Repositories.OrderRepositories;
using ECommerceApp.Persistence.Repositories.ProductRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceAppDbContext>(options => options.UseNpgsql(Configuration.ConnectionString), ServiceLifetime.Singleton);
            services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
