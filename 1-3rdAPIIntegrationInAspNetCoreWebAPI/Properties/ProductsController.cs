using _1_3rdAPIIntegrationInAspNetCoreWebAPI.Interfaces;
using _1_3rdAPIIntegrationInAspNetCoreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1_3rdAPIIntegrationInAspNetCoreWebAPI.Properties
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProducts _productService;

        public ProductsController(IProducts productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductsResponse>> GetProducts()
        {
           return await _productService.GetProductsAsync();
        }
    }
}
