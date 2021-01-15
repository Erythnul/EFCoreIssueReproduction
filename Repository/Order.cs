using System;
using System.Collections.Generic;

namespace RepositoryWithCompositeKeys
{
    public class Order
    {
        public int CustomerParentCompanyId { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }

        public Guid Id { get; set; }

        public int? IntOnOtherSideOfDB { get; set; }

        public Customer Customer { get; set; } = null!;
    }
}
