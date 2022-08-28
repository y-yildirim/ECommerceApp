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
            services.AddDbContext<ECommerceAppDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
