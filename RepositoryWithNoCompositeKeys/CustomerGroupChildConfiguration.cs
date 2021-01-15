using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace RepositoryWithNoCompositeKeys
{
    public class CustomerGroupChildConfiguration : IEntityTypeConfiguration<CustomerGroupChild>
    {
        public void Configure(EntityTypeBuilder<CustomerGroupChild> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(new List<CustomerGroupChild>
            {
                new CustomerGroupChild { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Description = "Something", CustomerGroupChildNumber = 1, CustomerGroupId = Guid.Parse("00000000-0000-0000-0000-000000000003")   },
                new CustomerGroupChild { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), Description = "SomethingElse", CustomerGroupChildNumber = 2, CustomerGroupId = Guid.Parse("00000000-0000-0000-0000-000000000003")  }
            });
        }
    }
}