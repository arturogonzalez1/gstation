using GStation.Core.Models;

namespace GStation.Services.Interfaces
{
    public interface ILocationService
    {
        Task<State> GetStateById(Guid id);
        Task<List<State>> GetStatesByCountryId(Guid id);
        Task<List<Country>> GetCountries();
    }
}
