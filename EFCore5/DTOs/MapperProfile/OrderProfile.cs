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
                .ForMember(dst => dst.MostImportantOrderLine, opt => opt.MapFrom(src => src.OrderLines.FirstOrDefault(x=>x.OrderLineNumber == src.MostImportantOrderLine)));

            CreateMap<RepositoryWithCompositeKeys.OrderLine, OrderLineModel>()
                .ForMember(dst => dst.OrderLineId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<RepositoryWithNoCompositeKeys.Order, OrderModel>()
                .ForMember(dst => dst.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.MostImportantOrderLine, opt => opt.MapFrom(src => src.OrderLines.FirstOrDefault(x=>x.OrderLineNumber == src.MostImportantOrderLine)));

            CreateMap<RepositoryWithNoCompositeKeys.OrderLine, OrderLineModel>()
                .ForMember(dst => dst.OrderLineId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
