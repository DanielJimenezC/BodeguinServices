using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Application.Communication.Request
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
