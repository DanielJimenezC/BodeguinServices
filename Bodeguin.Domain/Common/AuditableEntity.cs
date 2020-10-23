using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Domain.Common
{
    public abstract class AuditableEntity
    {
        public bool Active { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
