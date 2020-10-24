using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bodeguin.Application.Communication.Request;
using Bodeguin.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bodeguin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> getUserById(int id)
        {
            var result = await _userService.GetUser(id);
            if (!result.Valid)
                return new BadRequestObjectResult(result);
            return new OkObjectResult(result);
        }

        [Authorize]
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateRequest userUpdateRequest)
        {
            var result = await _userService.UpdateUser(id, userUpdateRequest);
            if (!result.Valid)
                return new BadRequestObjectResult(result);
            return new OkObjectResult(result);
        }
    }
}
