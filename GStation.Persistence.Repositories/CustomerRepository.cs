using GStation.Core.Models;
using GStation.Persistence.EF;
using GStation.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GStation.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Manager> Create(Manager customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Team> CreateVehicle(Team vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();

            return vehicle;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Manager>> GetAll()
        {
            return await _context.Customers.Include(c => c.Person).ToListAsync();
        }

        public async Task<List<Team>> GetAllVehicles(Guid customerId)
        {
            return await _context.Vehicles.Where(v => v.CustomerId == customerId).ToListAsync();
        }

        public async Task<Manager> GetById(Guid id)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
        }

        public Task<Manager> Update(Manager customer)
        {
            throw new NotImplementedException();
        }

        public async Task<Manager> GetByPersonId(Guid personId)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.PersonId == personId);
        }
    }
}
