using AutoMapper;
using GStation.Core.Models;
using GStation.Core.Models.DTOs;

namespace GStation.Core.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<UserSignupDto, ApplicationUser>()
                .ForMember(user => user.UserName, map => map.MapFrom(dto => dto.Email))
                .ReverseMap();
        }
    }
}
