using GStation.Core.Models;
using GStation.Persistence.EF.Seed.Fixtures;
using Microsoft.EntityFrameworkCore;

namespace GStation.Persistence.EF.Seed
{
    public static class UbicationSeed
    {
        public static void SeedUbication(this ApplicationDbContext context)
        {
            if (!context.Countries.ToListAsync().Result.Any() && !context.States.ToListAsync().Result.Any())
            {
                var mexicoStates = UbicationFixtures.GetMexicoStates();

                var mexico = new Country()
                {
                    Name = "México",
                    Abbreviation = "Mx",
                    States = mexicoStates
                };

                context.Countries.AddAsync(mexico);
                context.SaveChanges();
            }
        }
    }
}
