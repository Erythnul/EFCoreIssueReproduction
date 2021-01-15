using System;
using System.Collections.Generic;

namespace RepositoryWithCompositeKeys
{
    public class Order
    {
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }

        public Guid Id { get; set; }

        public int? MostImportantOrderLine { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; } = null!;
    }
}
