using Bodeguin.Application.Communication;
using Bodeguin.Application.Communication.Request;
using Bodeguin.Application.Communication.Response;
using System.Threading.Tasks;

namespace Bodeguin.Application.Interface
{
    public interface ILoginService
    {
        Task<JsonResult<LoginResponse>> SignIn(LoginRequest loginRequest);
        Task<JsonResult<LoginResponse>> SignUp(SignUpRequest signUpRequest);
    }
}
