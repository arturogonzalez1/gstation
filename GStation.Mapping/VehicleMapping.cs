using AutoMapper;
using GStation.Core.Models;
using GStation.Core.Models.DTOs;

namespace GStation.Core.Mapping
{
    public class VehicleMapping : Profile
    {
        public VehicleMapping()
        {
            CreateMap<CreateVehicleDto, Team>();
            CreateMap<Team, VehicleDto>();
        }
    }
}
