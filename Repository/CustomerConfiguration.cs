using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace RepositoryWithCompositeKeys
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => new { x.CompanyId, x.CustomerId });

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.CompanyId);

            builder.HasOne(x => x.Group)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => new { x.CompanyId, x.CustomerGroupId });

            builder.HasData(new Customer { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), CompanyId = 1, CustomerId = 2, CustomerGroupId = 3 });
        }
    }
}