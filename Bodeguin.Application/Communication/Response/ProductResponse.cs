using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Application.Communication.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public int NumStore { get; set; }
    }
}
