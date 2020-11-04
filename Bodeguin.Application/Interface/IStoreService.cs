using Bodeguin.Application.Communication;
using Bodeguin.Application.Communication.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bodeguin.Application.Interface
{
    public interface IStoreService
    {
        Task<JsonResult<List<StoreResponse>>> GetStores();
    }
}
