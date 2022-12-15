using GStation.Core.Models;
using GStation.Persistence.Repositories.Interfaces;
using GStation.Services.Interfaces;

namespace GStation.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> GetPersonById(Guid id)
        {
            return await _personRepository.GetPersonById(id);
        }
    }
}
