using System;

namespace RepositoryWithCompositeKeys
{
    public class CustomerGroupSubGroupChild
    {
        public Guid Id { get; set; }
        public int CustomerGroupSubGroupId { get; set; }
        public int CustomerGroupSubGroupChildId { get; set; }

        public int CustomerGroupSubGroupChildNumber { get; set; }

        public string Description { get; set; } = null!;
    }
}