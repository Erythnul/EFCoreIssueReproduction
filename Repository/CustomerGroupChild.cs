using System;

namespace RepositoryWithCompositeKeys
{
    public class CustomerGroupChild
    {
        public Guid Id { get; set; }
        public int CustomerGroupId { get; set; }
        public int CustomerGroupChildId { get; set; }

        public int CustomerGroupChildNumber { get; set; }

        public string Description { get; set; } = null!;
    }
}