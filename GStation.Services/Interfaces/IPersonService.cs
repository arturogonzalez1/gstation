using GStation.Core.Models;

namespace GStation.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Person> GetPersonById(Guid id);
    }
}
