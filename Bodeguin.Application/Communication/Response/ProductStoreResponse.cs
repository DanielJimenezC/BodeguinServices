using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Application.Communication.Response
{
    public class ProductStoreResponse
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
        public string MeasureUnit { get; set; }
        public string Store { get; set; }
        public string UrlImageProduct { get; set; }
        public string Product { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
