using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Security.Cryptography.X509Certificates;

namespace RepositoryWithNoCompositeKeys
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.CompanyId);

            builder.HasOne(x => x.Group)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.CustomerGroupId);

            builder.HasData(new Customer { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), CompanyId = Guid.Parse("00000000-0000-0000-0000-000000000010"), CustomerGroupId = Guid.Parse("00000000-0000-0000-0000-000000000003") });
        }
    }
}