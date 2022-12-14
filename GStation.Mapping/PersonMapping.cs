using AutoMapper;
using GStation.Core.Models;
using GStation.Core.Models.DTOs;

namespace GStation.Core.Mapping
{
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<PersonSignupDto, Person>().ReverseMap();
        }
    }
}
