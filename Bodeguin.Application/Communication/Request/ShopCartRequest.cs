using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Application.Communication.Request
{
    public class ShopCartRequest
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public List<DetailRequest> Detail { get; set; }
    }

    public class DetailRequest
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int InventoryId { get; set; }
    }
}
