using System;
using System.Collections.Generic;

namespace RepositoryWithNoCompositeKeys
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        public int? IntOnOtherSideOfDB { get; set; }

        public Customer Customer { get; set; } = null!;
    }
}
