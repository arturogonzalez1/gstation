using AutoMapper;
using GStation.Core.Models;
using GStation.Core.Models.DTOs;

namespace GStation.Core.Mapping
{
    public class CustomerAddressMapping : Profile
    {
        public CustomerAddressMapping()
        {
            CreateMap<CustomerAddressSetDto, CustomerAddress>();
        }
    }
}
