using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Security.Cryptography.X509Certificates;

namespace RepositoryWithCompositeKeys
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => new { x.CustomerParentCompanyId, x.CustomerId });

            builder.HasData(new Order
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                IntOnOtherSideOfDB = 2,
                CustomerParentCompanyId = 1,
                CustomerId = 2,
                OrderId = 1,
            });
        }
    }
}