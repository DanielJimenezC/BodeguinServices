using Bodeguin.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Domain.Entity
{
    public class Inventory : AuditableEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public Product Product { get; set; }
        public Store Store { get; set; }
    }
}
