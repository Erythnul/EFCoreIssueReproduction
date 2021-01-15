using System;
using System.Collections.Generic;

namespace RepositoryWithCompositeKeys
{
    public class CustomerGroup
    {
        public Guid Id { get; set; }

        public int CompanyId { get; set; }
        public int CustomerGroupId { get; set; }

        public int CustomerGroupSubGroupAlternateKey { get; set; }

        public CustomerGroupSubGroup SubGroup { get; set; }

        public ICollection<Customer> Customers { get; set; }
        public ICollection<CustomerGroupChild> Children { get; set; }
    }
}