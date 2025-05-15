using ECommerce.Basket.DTOs;
using ECommerce.Basket.Services.BasketServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController(IBasketService basketService) : ControllerBase
    {
        [HttpGet("{userId}")]

        public async Task<IActionResult> GetBasket(string userId)
        {
            var values = await basketService.GetBasketAsync(userId);
            if (values is null)
            {
                return NotFound();
            }
            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> SaveBasket(BasketDto basket)
        {
            if (basket is null)
            {
                return BadRequest("Basket not saved");
            }
            await basketService.SaveOrUpdateAsync(basket);
            return Ok("Basket Changes Saved");
        }

        [HttpDelete("{userId}")]

        public async Task<IActionResult> DeleteBasket(string userId)
        {
            var result = await basketService.DeleteAsync(userId);
            if (result)
            {
                return Ok("Basket Deleted");
            }
            return BadRequest("Basket Delete Failed");
        }
    }
}
