using AutoMapper;
using OrderManager.Entities;
using OrderManager.Models;

namespace OrderManager.API.Profiles;

public class VendorProfile : Profile
{
    public VendorProfile()
    {
        CreateMap<Vendor, VendorDto>();
    }
}
