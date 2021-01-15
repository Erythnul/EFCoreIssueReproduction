using System;

namespace EfCoreRepro.DTOs
{
    public class OrderLineModel
    {
        public Guid OrderLineId { get; set; }
        public string Description { get; set; }
    }
}