using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreRepro.DTOs
{
    public class OrderModel
    {
        public AddressModel? ShippingAddress { get; set; }
    }

    public class AddressModel
    {
        public string? Street { get; set; }
        public int HouseNumber { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
