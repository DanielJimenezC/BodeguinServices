
namespace Bodeguin.Application.Communication.Request
{
    public class SignUpRequest
    {
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
