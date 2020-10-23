using Bodeguin.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Domain.Entity
{
    public class Voucher : AuditableEntity
    {
        public int Id { get; set; }
        public int PaymentTypeId { get; set; }
        public int UserId { get; set; }
        public PaymentType PaymentType { get; set; }
        public User User { get; set; }
        public IList<Detail> Details { get; set; } = new List<Detail>();
    }
}
