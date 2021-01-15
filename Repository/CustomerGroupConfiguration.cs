using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Security.Cryptography.X509Certificates;

namespace RepositoryWithCompositeKeys
{
    public class CustomerGroupConfiguration : IEntityTypeConfiguration<CustomerGroup>
    {
        public void Configure(EntityTypeBuilder<CustomerGroup> builder)
        {
            builder.HasKey(x => new { x.CompanyId, x.CustomerGroupId });

            builder.HasOne(group => group.SubGroup)
                .WithMany(subgroup => subgroup.CustomerGroups)
                .HasPrincipalKey(subgroup => subgroup.CustomerGroupAlternateKey)
                .HasForeignKey(group => group.CustomerGroupSubGroupAlternateKey);


            builder.HasData(new CustomerGroup { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), CompanyId = 1, CustomerGroupId = 3, CustomerGroupSubGroupAlternateKey = 1000 });
        }
    }
}