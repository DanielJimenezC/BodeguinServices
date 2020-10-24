using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Application.Communication.Response
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Direction { get; set; }
        public string Dni { get; set; }
        public bool Active { get; set; }
        public bool Admin { get; set; }
        public string Token { get; set; }
    }
}
