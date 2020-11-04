using Bodeguin.Application.Communication;
using Bodeguin.Application.Communication.Request;
using System;
using System.Threading.Tasks;

namespace Bodeguin.Application.Interface
{
    public interface IShopService
    {
        public Task<JsonResult<String>> SaveShopCart(ShopCartRequest shopCartRequest);
    }
}
