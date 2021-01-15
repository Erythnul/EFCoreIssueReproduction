using System;

namespace RepositoryWithCompositeKeys
{
    public class OrderLine
    {
        public Guid Id { get; set; }

        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public int OrderLineId { get; set; }

        public int OrderLineNumber { get; set; }
        public string Description { get; set; }

        public Order Order { get; set; } = null!;
    }
}