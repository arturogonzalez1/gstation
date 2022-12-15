using GStation.Core.Models;

namespace GStation.Persistence.EF.Seed.Fixtures
{
    public static class PersonFixture
    {
        public static Person GetPerson() => new()
        { 
            Id = new Guid(),
            Name = String.Empty,
            PaternalSurname = String.Empty,
            MaternalSurname = String.Empty,
            PhoneNumber = String.Empty,
        };
    }
}
