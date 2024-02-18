using _1_3rdAPIIntegrationInAspNetCoreWebAPI.Interfaces;
using _1_3rdAPIIntegrationInAspNetCoreWebAPI.Models;
using System.Net;
using System.Text.Json;

namespace _1_3rdAPIIntegrationInAspNetCoreWebAPI.Services
{
    public class ProductService : IProducts
    {
        private static readonly HttpClient httpClient;

        static ProductService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://dummyjson.com/")
            };

        }

        public async Task<List<ProductsResponse>> GetProductsAsync()
        {
            try
            {
                var url = string.Format("products");
                var result = new List<ProductsResponse>();
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var productsResponse = JsonSerializer.Deserialize<ProductsResponse>(stringResponse, new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    // Add the deserialized ProductsResponse to the result list
                    result.Add(productsResponse);
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("Products not found.");
                    }
                    else
                    {
                        throw new Exception("Failed to fetch data from the server. Status code: " + response.StatusCode);
                    }
                }

                return result;

            }
            catch (HttpRequestException ex)
            {
                throw new Exception("HTTP request failed: " + ex.Message);
            }
            catch (JsonException ex)
            {
                throw new Exception("JSON deserialization failed: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
