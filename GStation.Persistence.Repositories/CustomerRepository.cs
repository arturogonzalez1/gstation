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

        public async Task<Customer> Create(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();

            return vehicle;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.Include(c => c.Person).ToListAsync();
        }

        public async Task<List<Vehicle>> GetAllVehicles(Guid customerId)
        {
            return await _context.Vehicles.Where(v => v.CustomerId == customerId).ToListAsync();
        }

        public async Task<Customer> GetById(Guid id)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
        }

        public Task<Customer> Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
