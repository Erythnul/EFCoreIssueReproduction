using RepositoryWithNoCompositeKeys;
using System;
using System.Collections.Generic;

namespace RepositoryWithNoCompositeKeys
{
    public class Company
    {
        public Guid Id { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}