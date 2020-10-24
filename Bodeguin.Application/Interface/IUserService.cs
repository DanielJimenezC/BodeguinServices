using Bodeguin.Application.Communication;
using Bodeguin.Application.Communication.Request;
using Bodeguin.Application.Communication.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bodeguin.Application.Interface
{
    public interface IUserService
    {
        Task<JsonResult<UserResponse>> UpdateUser(int id, UserUpdateRequest userUpdateRequest);
        Task<JsonResult<UserResponse>> GetUser(int id);
    }
}
