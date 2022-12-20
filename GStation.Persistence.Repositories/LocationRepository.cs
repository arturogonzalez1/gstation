using GStation.Core.Models;
using GStation.Persistence.EF;
using GStation.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GStation.Persistence.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<State>> GetStatesByCountryId(Guid id)
        {
            return await _context.States.Where(s => s.CountryId == id).ToListAsync();
        }

        public async Task<List<Country>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }
    }
}
