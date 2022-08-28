using ECommerceApp.Application.Repositories.CustomerRepositories;
using ECommerceApp.Application.Repositories.OrderRepositories;
using ECommerceApp.Application.Repositories.ProductRepositories;
using ECommerceApp.Persistence.Repositories.OrderRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        [HttpGet]
        public async void CreateProductSamples()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() {Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreatedAt = DateTime.UtcNow, Stock = 10},
                new() {Id = Guid.NewGuid(), Name = "Product 2", Price = 200, CreatedAt = DateTime.UtcNow, Stock = 20},
                new() {Id = Guid.NewGuid(), Name = "Product 3", Price = 300, CreatedAt = DateTime.UtcNow, Stock = 30},
            });
            await _productWriteRepository.SaveAsync();
        }

        // Test
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //await _customerWriteRepository.AddAsync(new() { Name = "fyVS" });
            //await _customerWriteRepository.SaveAsync();
            await _orderWriteRepository.AddAsync(new() { Adress = "Istanbul", Description = "asdfasdf", CustomerId = Guid.Parse("667ba257-d208-4c48-a11a-764edf4e5a50") });
            await _orderWriteRepository.SaveAsync();

            return Ok();
        }
    }
}
