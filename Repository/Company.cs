using System;
using System.Collections.Generic;

namespace RepositoryWithCompositeKeys
{
    public class Company
    {
        public Guid Id { get; set; }

        public int CompanyId { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}