using GStation.Core.Models;
using GStation.Persistence.Repositories.Interfaces;
using GStation.Services.Interfaces;

namespace GStation.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<State>> GetStatesByCountryId(Guid id)
        {
            return await _locationRepository.GetStatesByCountryId(id);
        }

        public async Task<List<Country>> GetCountries()
        {
            return await _locationRepository.GetCountries();
        }

    }
}
