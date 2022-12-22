using AutoMapper;
using GStation.Core.Models;
using GStation.Persistence.Repositories.Interfaces;
using GStation.Services.Interfaces;

namespace GStation.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository, IAuthService authService)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Create(Customer customer)
        {
            return await _customerRepository.Create(customer);
        }

        public async Task DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _customerRepository.GetAll();
        }

        public async Task<Customer> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
