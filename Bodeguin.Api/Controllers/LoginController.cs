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
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginRequest loginRequest)
        {
            var result = await _loginService.SignIn(loginRequest);
            if (!result.Valid)
                return new NotFoundObjectResult(result);
            return new OkObjectResult(result);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> SignUp(SignUpRequest signUpRequest)
        {
            var result = await _loginService.SignUp(signUpRequest);
            if (!result.Valid)
                return new BadRequestObjectResult(result);
            return new OkObjectResult(result);
        }
    }
}
