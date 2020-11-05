using Bodeguin.Application.Communication;
using Bodeguin.Application.Communication.Request;
using Bodeguin.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bodeguin.Application.Interface
{
    public interface IPurchaseService
    {
        public Task<JsonResult<String>> SaveShopCart(ShopCartRequest shopCartRequest);
        public Task<JsonResult<List<Voucher>>> GetShopCart(int userId);
        public Task<JsonResult<object>> GetDetailShopCart(int id);
    }
}
