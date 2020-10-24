using Bodeguin.Application.Communication.Request;
using System.Threading.Tasks;

namespace Bodeguin.Application.Security.JsonWebToken
{
    public interface IJWTFactory
    {
        Task<string> GetJWT(string loginRequest);
    }
}
