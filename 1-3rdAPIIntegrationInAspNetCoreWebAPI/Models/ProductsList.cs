using System.Text.Json.Serialization;

namespace _1_3rdAPIIntegrationInAspNetCoreWebAPI.Models
{
    public class ProductsResponse
    {
        public List<Product> Products { get; set; }
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }
}
