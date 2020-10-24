using Bodeguin.Application.Communication.Request;
using Bodeguin.Application.Communication.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bodeguin.Application.Security
{
    public interface IJWTFactory
    {
        Task<string> GetJWT(LoginRequest loginRequest);
    }
}
