using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace RepositoryWithCompositeKeys
{
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.HasKey(x => new { x.CompanyId, x.CustomerId, x.OrderId, x.OrderLineId });

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderLines)
                .HasForeignKey(x => new { x.CompanyId, x.CustomerId, x.OrderId });

            builder.HasData(new[]
            {
                new OrderLine
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000101"),
                    CompanyId = 1,
                    CustomerId = 2,
                    OrderId = 1,
                    OrderLineId = 1,
                    OrderLineNumber = 2,
                    Description = "ChessSet"
                },
                new OrderLine
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000102"),
                    CompanyId = 1,
                    CustomerId = 2,
                    OrderId = 1,
                    OrderLineId = 2,
                    OrderLineNumber = 3,
                    Description = "NotAChessSet"
                }
            });
        }
    }
}