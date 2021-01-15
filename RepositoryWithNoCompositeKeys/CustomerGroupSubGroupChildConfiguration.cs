﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace RepositoryWithNoCompositeKeys
{
    public class CustomerGroupSubGroupChildConfiguration : IEntityTypeConfiguration<CustomerGroupSubGroupChild>
    {
        public void Configure(EntityTypeBuilder<CustomerGroupSubGroupChild> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(new List<CustomerGroupSubGroupChild>
            {
                new CustomerGroupSubGroupChild { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Description = "Something", CustomerGroupSubGroupChildNumber = 1, CustomerGroupSubGroupId = Guid.Parse("00000000-0000-0000-0000-000000000004")   },
                new CustomerGroupSubGroupChild { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Description = "SomethingElse", CustomerGroupSubGroupChildNumber = 2, CustomerGroupSubGroupId = Guid.Parse("00000000-0000-0000-0000-000000000004")  }
            });
        }
    }
}