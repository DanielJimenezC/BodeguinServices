using Bodeguin.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Domain.Entity
{
    public class Product : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IList<Inventory> Inventories { get; set; } = new List<Inventory>();
    }
}
