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

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.Include(c => c.Person).ToListAsync();
        }

        public Task<Customer> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
