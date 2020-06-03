using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BasketManagement.Controllers
{
    [ApiController]
    [Route("api/basket")]
    public class BasketController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddToBasket()
        {
            return Ok("");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBasketItem()
        {
            return Ok("");
        }

        [HttpGet]
        public async Task<IActionResult> ViewBasket()
        {
            return Ok("");
        }
        
        
    }
}