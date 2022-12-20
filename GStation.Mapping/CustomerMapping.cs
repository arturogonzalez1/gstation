using AutoMapper;
using GStation.Core.Models;
using GStation.Core.Models.DTOs;

namespace GStation.Core.Mapping
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<CustomerSignupDto, Customer>().ReverseMap();
        }
    }
}
