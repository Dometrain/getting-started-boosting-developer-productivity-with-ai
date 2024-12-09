using AutoMapper;
using OrderManager.API.Models;
using OrderManager.Entities;
using OrderManager.Models;

namespace OrderManager.API.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>();
        CreateMap<OrderWithOrderLinesForCreationDto, Order>();
    }
}
