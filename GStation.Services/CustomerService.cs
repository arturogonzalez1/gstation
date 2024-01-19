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

        public async Task<Manager> Create(Manager customer)
        {
            return await _customerRepository.Create(customer);
        }

        public async Task<Team> CreateVehicle(Team vehicle)
        {
            return await _customerRepository.CreateVehicle(vehicle);
        }

        public Task DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Manager>> GetAll()
        {
            return await _customerRepository.GetAll();
        }

        public async Task<List<Team>> GetAllVehicles(Guid customerId)
        {
            return await _customerRepository.GetAllVehicles(customerId);
        }

        public Task<Manager> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Manager> Update(Manager customer)
        {
            throw new NotImplementedException();
        }

        public async Task<Manager> GetCustomerByUserId(string userId)
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
