using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace RepositoryWithNoCompositeKeys
{
    public class CustomerGroupSubGroupConfiguration : IEntityTypeConfiguration<CustomerGroupSubGroup>
    {
        public void Configure(EntityTypeBuilder<CustomerGroupSubGroup> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(new CustomerGroupSubGroup { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), CustomerGroupAlternateKey = 1000 });
        }
    }
}