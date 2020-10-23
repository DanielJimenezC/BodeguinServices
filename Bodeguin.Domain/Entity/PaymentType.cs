using Bodeguin.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Domain.Entity
{
    public class PaymentType : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Voucher> Vouchers { get; set; } = new List<Voucher>();
    }
}
