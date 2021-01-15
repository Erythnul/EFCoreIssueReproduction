using RepositoryWithNoCompositeKeys;
using System;
using System.Collections.Generic;

namespace RepositoryWithNoCompositeKeys
{
    public class Customer
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }
        public Guid CustomerGroupId { get; set; }

        public Company Company { get; set; } = null!;
        public CustomerGroup Group { get; set; } = null!;

        public ICollection<Order> Orders { get; set; } = null!;
    }
}