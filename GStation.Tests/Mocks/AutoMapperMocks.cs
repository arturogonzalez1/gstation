using AutoMapper;
using GStation.Core.Mapping;

namespace GStation.Tests.Mocks
{
    internal static class AutoMapperMocks
    {
        public static IMapper GetAutoMapper()
        {
            var profiles = new List<Profile>();

            profiles.Add(new AddressMapping());
            profiles.Add(new CustomerAddressMapping());
            profiles.Add(new CustomerMapping());
            profiles.Add(new PersonMapping());
            profiles.Add(new UserMapping());

            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(profiles));

            return new Mapper(configuration);
        }
    }
}
