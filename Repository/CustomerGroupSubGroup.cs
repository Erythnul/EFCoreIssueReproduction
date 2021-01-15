using System;
using System.Collections.Generic;

namespace RepositoryWithCompositeKeys
{
    public class CustomerGroupSubGroup
    {
        public Guid Id { get; set; }

        public int CustomerSubGroupId { get; set; }

        public int CustomerGroupAlternateKey { get; set; }

        public ICollection<CustomerGroup> CustomerGroups { get; set; }
        public ICollection<CustomerGroupSubGroupChild> Children { get; set; }
    }
}