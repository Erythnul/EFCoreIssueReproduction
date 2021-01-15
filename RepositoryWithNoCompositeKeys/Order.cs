using System;
using System.Collections.Generic;

namespace RepositoryWithNoCompositeKeys
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        public int? MostImportantOrderLine { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; } = null!;
    }
}
