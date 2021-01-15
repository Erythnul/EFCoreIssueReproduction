using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Security.Cryptography.X509Certificates;

namespace RepositoryWithNoCompositeKeys
{
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderLines)
                .HasForeignKey(x => x.OrderId);

            builder.HasData(new[]
            {
                new OrderLine
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000101"),
                    OrderId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    OrderLineNumber = 2,
                    Description = "ChessSet"
                },
                new OrderLine
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000102"),
                    OrderId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    OrderLineNumber = 3,
                    Description = "NotAChessSet"
                }
            });
        }
    }
}