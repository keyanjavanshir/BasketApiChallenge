using System.Text.Json;
using BasketApi.Models;
using Microsoft.AspNetCore.Mvc;

public class ImpactProductStrategy : IProductStrategy
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ImpactProductStrategy(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    private async Task<List<Product>> GetAllProducts()
    {
        // Fetch all products
        var client = _httpClientFactory.CreateClient("AuthenticatedClient");
        var response = await client.GetAsync("https://azfun-impact-code-challenge-api.azurewebsites.net/api/GetAllProducts");

        // Check if the request was successful
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to fetch products: {response.StatusCode}");
        }

        // Deserialize the response content
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Product>>(content);
    }

    public async Task<IActionResult> GetTop100Products()
    {
        // Fetch all products
        var products = await GetAllProducts();

        // Get the top 100 products by ranking
        var top100Products = products
            .OrderByDescending(p => p.stars)
            .Take(100)
            .ToList();

        return new OkObjectResult(top100Products);
    }

    public async Task<IActionResult> GetTop10CheapestProducts()
    {
        // Fetch all products
        var products = await GetAllProducts();

        //  Get the top 10 cheapest products
        var top10CheapestProducts = products
            .OrderBy(p => p.price)
            .Take(10)
            .ToList();

        return new OkObjectResult(top10CheapestProducts);
    }

    public async Task<IActionResult> GetProductsWithPagination(int page, int pageSize)
    {
        // Validate the page and pageSize values
        if (page <= 0 || pageSize <= 0 || pageSize > 1000)
        {
            return new BadRequestObjectResult("Invalid page or pageSize values");
        }

        var products = await GetAllProducts();

        // Paginate the products based on the page and pageSize
        var paginatedProducts = products
            .OrderByDescending(p => p.price)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new OkObjectResult(paginatedProducts);
    }
}
