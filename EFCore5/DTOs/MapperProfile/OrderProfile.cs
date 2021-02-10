using AutoMapper;
using System.Linq;

namespace EfCoreRepro.DTOs.MapperProfile
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            //AllowNullDestinationValues = false;

            CreateMap<Repository.Order, OrderModel>()
                .ForMember(dst => dst.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddress.Country != null ? src.ShippingAddress : default))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Repository.Address, AddressModel>();

        }
    }
}
