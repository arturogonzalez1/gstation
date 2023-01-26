using AutoMapper;
using GStation.Core.Mapping;

namespace GStation.Tests.Mocks;

public static class AutoMapperMocks
{
    public static IMapper GetMock() {

        var profiles = new List<Profile>
        {
            new AddressMapping(),
            new CustomerAddressMapping(),
            new CustomerMapping(),
            new PersonMapping(),
            new UserMapping()
        };

        var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(profiles));

        return new Mapper(configuration);
    }
}