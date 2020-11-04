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
    public class StoresController : ControllerBase
    {
        private readonly IStoreService _storeService;
        
        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            var result = await _storeService.GetStores();
            return new OkObjectResult(result);
        }
    }
}
