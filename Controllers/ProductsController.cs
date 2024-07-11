using Api.Models;
using Api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet] 
        public async Task<List<Product>> GetProducts() => await _productService.GetAsync();

        [HttpPost]
        public async Task<Product> PostProduct(Product product)
        {
            await _productService.CreateAsync(product);
            return product;
        }
        
    }
}
