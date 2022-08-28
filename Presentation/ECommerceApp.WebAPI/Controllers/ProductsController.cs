using ECommerceApp.Application.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
