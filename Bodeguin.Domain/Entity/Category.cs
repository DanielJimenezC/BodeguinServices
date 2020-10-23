using Bodeguin.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Domain.Entity
{
    public class Category : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
