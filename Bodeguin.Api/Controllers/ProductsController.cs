using System.Threading.Tasks;
using Bodeguin.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bodeguin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetSearchProduct([FromQuery] string search)
        {
            var result = await _productService.GetSearchProduct(search);
            return new OkObjectResult(result);
        }

        [Authorize]
        [HttpGet("{id}/stores")]
        public async Task<IActionResult> GetStoresByProduct(int id)
        {
            var result = await _productService.GetStoreByProduct(id);
            return new OkObjectResult(result);
        }
    }
}
