using System;

namespace RepositoryWithNoCompositeKeys
{
    public class OrderLine
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }

        public int OrderLineNumber { get; set; }
        public string Description { get; set; }

        public Order Order { get; set; } = null!;
    }
}