using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Domain.Entity
{
    public class Detail
    {
        public int Id { get; set; }
        public int Discount { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int VoucherId { get; set; }
        public Product Product { get; set; }
        public Voucher Voucher { get; set; }
    }
}
