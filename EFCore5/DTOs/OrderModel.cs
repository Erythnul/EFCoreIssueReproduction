using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreRepro.DTOs
{
    public class OrderModel
    {
        public Guid? OrderId { get; set; }
        public OrderLineModel MostImportantOrderLine { get; set; }
    }
}
