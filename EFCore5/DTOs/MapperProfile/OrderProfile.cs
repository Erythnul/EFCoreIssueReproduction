using AutoMapper;
using System.Linq;

namespace EfCoreRepro.DTOs.MapperProfile
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<RepositoryWithCompositeKeys.Order, OrderModel>()
                .ForMember(dst => dst.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.MostImportantOrderLine, opt => opt.MapFrom(src => src.Customer.Group.SubGroup.Children.FirstOrDefault(x => x.CustomerGroupSubGroupChildNumber == src.IntOnOtherSideOfDB)));

            CreateMap<RepositoryWithCompositeKeys.CustomerGroupSubGroupChild, OrderLineModel>()
                .ForMember(dst => dst.OrderLineId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<RepositoryWithCompositeKeys.CustomerGroupChild, OrderLineModel>()
                .ForMember(dst => dst.OrderLineId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<RepositoryWithNoCompositeKeys.Order, OrderModel>()
                .ForMember(dst => dst.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.MostImportantOrderLine, opt => opt.MapFrom(src => src.Customer.Group.SubGroup.Children.FirstOrDefault(x => x.CustomerGroupSubGroupChildNumber == src.IntOnOtherSideOfDB)));

            CreateMap<RepositoryWithNoCompositeKeys.CustomerGroupSubGroupChild, OrderLineModel>()
                .ForMember(dst => dst.OrderLineId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<RepositoryWithNoCompositeKeys.CustomerGroupChild, OrderLineModel>()
                .ForMember(dst => dst.OrderLineId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
