using System;
using System.Collections.Generic;

namespace RepositoryWithCompositeKeys
{
    public class Customer
    {
        public Guid Id { get; set; }

        public int CompanyId { get; set; }
        public int CustomerId { get; set; }

        public int CustomerGroupId { get; set; }

        public Company Company { get; set; } = null!;
        public CustomerGroup Group { get; set; } = null!;

        public ICollection<Order> Orders { get; set; } = null!;
    }
}