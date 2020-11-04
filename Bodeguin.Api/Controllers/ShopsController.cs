using System.Threading.Tasks;
using Bodeguin.Application.Communication.Request;
using Bodeguin.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bodeguin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopsController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddShopCart([FromBody] ShopCartRequest shopCartRequest)
        {
            var result = await _shopService.SaveShopCart(shopCartRequest);
            return new OkObjectResult(result);
        }
    }
}
