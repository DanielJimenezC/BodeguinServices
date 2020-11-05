using System.Threading.Tasks;
using Bodeguin.Application.Communication.Request;
using Bodeguin.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bodeguin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseService _shopService;

        public PurchasesController(IPurchaseService shopService)
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShopCarts(int id)
        {
            var result = await _shopService.GetShopCart(id);
            return new OkObjectResult(result);
        }
    }
}
