using System;

namespace RepositoryWithNoCompositeKeys
{
    public class CustomerGroupSubGroupChild
    {
        public Guid Id { get; set; }
        public Guid CustomerGroupSubGroupId { get; set; }

        public int CustomerGroupSubGroupChildNumber { get; set; }

        public string Description { get; set; } = null!;
    }
}