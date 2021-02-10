using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Repository
{
    public class Order
    {
        public Guid Id { get; set; }

        public Address? ShippingAddress { get; set; }
    }

    public class Address
    {
        public Guid OrderId { get; set; }

        public string? Street { get; set; }
        public int HouseNumber { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(new Order
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001")
            });

            builder.OwnsOne(o => o.ShippingAddress, o => o.HasData(new Address
            {
                OrderId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Street = "TestStreet",
                HouseNumber = 3,
                City = "TestCity",
                Country = "TestCountry"
            }));
        }
    }
}
