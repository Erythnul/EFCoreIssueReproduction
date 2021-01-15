using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Security.Cryptography.X509Certificates;

namespace RepositoryWithNoCompositeKeys
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(new Order
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                MostImportantOrderLine = 2,
            });
        }
    }
}