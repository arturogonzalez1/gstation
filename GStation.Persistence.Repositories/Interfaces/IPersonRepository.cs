using GStation.Core.Models;

namespace GStation.Persistence.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> GetPersonById(Guid id);
    }
}
