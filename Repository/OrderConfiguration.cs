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
            builder.HasKey(x => new { x.CompanyId, x.CustomerId, x.OrderId });

            builder.HasData(new Order
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                MostImportantOrderLine = 2,
                CompanyId = 1,
                CustomerId = 2,
                OrderId = 1
            });
        }
    }
}