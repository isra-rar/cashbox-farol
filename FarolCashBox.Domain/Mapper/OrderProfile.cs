using AutoMapper;
using FarolCashBox.Domain.Commands.Response;
using FarolCashBox.Domain.Entities;

namespace FarolCashBox.Domain.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, CreateOrderResponse>()
                .ForMember(src => src.Products, opt => opt.MapFrom(src => src.Products));
        }
    }
}
