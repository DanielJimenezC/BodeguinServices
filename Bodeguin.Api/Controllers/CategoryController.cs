using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bodeguin.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bodeguin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoryService.GetCategories();
            return new OkObjectResult(result);
        }
    }
}
