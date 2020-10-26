using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Application.Communication.Response
{
    public class ProductStoreResponse
    {
        //id of inventory
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
        public string MeasureUnit { get; set; }
        public string Store { get; set; }
    }
}
