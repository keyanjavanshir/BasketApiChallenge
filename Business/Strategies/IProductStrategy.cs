using System.Collections.Generic;
using System.Threading.Tasks;
using BasketApi.Models;
using Microsoft.AspNetCore.Mvc;

public interface IProductStrategy
{
    Task<IActionResult> GetTop100Products();
    Task<IActionResult> GetTop10CheapestProducts();
    Task<IActionResult> GetProductsWithPagination(int page, int pageSize);
}