using AutoMapper;
using OrderManager.Entities;
using OrderManager.Models;

namespace OrderManager.API.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}
