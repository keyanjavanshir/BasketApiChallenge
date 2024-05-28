using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BasketApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImpactApiController : ControllerBase
    {
        private readonly IProductStrategy _impactProductStrategy;

        public ImpactApiController(IProductStrategy impactProductStrategy)
        {
            _impactProductStrategy = impactProductStrategy;
        }

        [HttpGet("Top100Products")]
        public Task<IActionResult> GetTop100Products()
        {
            return _impactProductStrategy.GetTop100Products();
        }

        [HttpGet("Top10CheapestProducts")]
        public Task<IActionResult> GetTop10CheapestProducts()
        {
            return _impactProductStrategy.GetTop10CheapestProducts();
        }

        [HttpGet("GetProductsWithPagination")]
        public Task<IActionResult> GetProductsWithPagination(int page, int pageSize)
        {
            return _impactProductStrategy.GetProductsWithPagination(page, pageSize);
        }
    }
}