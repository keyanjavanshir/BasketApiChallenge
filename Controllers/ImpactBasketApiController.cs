using Microsoft.AspNetCore.Mvc;
using BasketApi.Models;

namespace BasketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("GetBasketById/{id}")]
        public async Task<ActionResult<Basket>> GetBasket(Guid id)
        {
            // Get the basket by id from the service
            var basket = await _basketService.GetBasketAsync(id);
            if (basket == null)
            {
                return NotFound();
            }
            return basket;
        }

        [HttpPost("CreateNewBasket")]
        public async Task<ActionResult<Basket>> CreateBasket(string userEmail)
        {
            // Create a new basket and return it
            var basket = await _basketService.CreateBasketAsync(userEmail);
            return CreatedAtAction(nameof(GetBasket), new { id = basket.Id }, basket);
        }

        [HttpPut("UpdateBasketById/{id}")]
        public async Task<IActionResult> UpdateBasket(Guid id, Basket basket)
        {
            if (id != basket.Id)
            {
                return BadRequest();
            }

            var updatedBasket = await _basketService.UpdateBasketAsync(basket);
            return Ok(updatedBasket);
        }
    }
}