using GStation.Core.Models;

namespace GStation.Services.Interfaces
{
    public interface ILocationService
    {
        Task<List<State>> GetStatesByCountryId(Guid id);
        Task<List<Country>> GetCountries();
    }
}
