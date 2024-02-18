using _1_3rdAPIIntegrationInAspNetCoreWebAPI.Models;

namespace _1_3rdAPIIntegrationInAspNetCoreWebAPI.Interfaces
{
    public interface IProducts
    {
        Task<List<ProductsResponse>> GetProductsAsync();
    }
}
