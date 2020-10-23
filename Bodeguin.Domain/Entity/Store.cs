using Bodeguin.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Domain.Entity
{
    public class Store : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ruc { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Direction { get; set; }
        public string Description { get; set; }
        public IList<Inventory> Inventories { get; set; } = new List<Inventory>();
    }
}
