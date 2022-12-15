using GStation.Core.Models;
using GStation.Persistence.EF;
using GStation.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GStation.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Person> GetPersonById(Guid id)
        {
            return await _context.Persons.SingleOrDefaultAsync(person => person.Id == id);
        }
    }
}
