using GStation.Core.Models;

namespace GStation.Persistence.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        Task<State> GetStateById(Guid id);
        Task<List<State>> GetStatesByCountryId(Guid id);
        Task<List<Country>> GetCountries();
    }
}
