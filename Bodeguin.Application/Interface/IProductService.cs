using Bodeguin.Application.Communication;
using Bodeguin.Application.Communication.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bodeguin.Application.Interface
{
    public interface IProductService
    {
        Task<JsonResult<List<ProductResponse>>> GetSearchProduct(string search);
        Task<JsonResult<List<ProductStoreResponse>>> GetStoreByProduct(int id);
    }
}
