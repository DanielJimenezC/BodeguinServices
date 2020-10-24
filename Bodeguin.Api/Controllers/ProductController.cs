using System.Threading.Tasks;
using Bodeguin.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bodeguin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
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
    }
}
