using AutoMapper;
using GStation.Core.Models;
using GStation.Persistence.Repositories.Interfaces;
using GStation.Services.Interfaces;

namespace GStation.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAuthService _authService;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository, IAuthService authService)
        {
            _customerRepository = customerRepository;
            _authService = authService;
        }

        public async Task<Customer> Create(Customer customer)
        {
            return await _customerRepository.Create(customer);
        }

        public async Task<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            return await _customerRepository.CreateVehicle(vehicle);
        }

        public Task DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _customerRepository.GetAll();
        }

        public async Task<List<Vehicle>> GetAllVehicles(Guid customerId)
        {
            return await _customerRepository.GetAllVehicles(customerId);
        }

        public Task<Customer> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetCustomerByUserId(string userId)
        {
            var person = await _authService.GetPersonByUserId(userId);

            if (person == null)
            {
                return null;
            }

            return await _customerRepository.GetByPersonId(person.Id);
        }
    }
}
