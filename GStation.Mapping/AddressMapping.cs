using AutoMapper;
using GStation.Core.Models;
using GStation.Core.Models.DTOs;

namespace GStation.Core.Mapping
{
    public class AddressMapping : Profile
    {
        public AddressMapping()
        {
            CreateMap<AddressSetDto, Address>();
        }
    }
}
