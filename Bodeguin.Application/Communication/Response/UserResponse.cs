using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Application.Communication.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Direction { get; set; }
        public string Dni { get; set; }
    }
}
