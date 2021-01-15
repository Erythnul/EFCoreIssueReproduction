using System;

namespace RepositoryWithNoCompositeKeys
{
    public class CustomerGroupChild
    {
        public Guid Id { get; set; }
        public Guid CustomerGroupId { get; set; }

        public int CustomerGroupChildNumber { get; set; }

        public string Description { get; set; } = null!;
    }
}