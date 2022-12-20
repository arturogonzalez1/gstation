using AutoMapper;
using GStation.Core.Models;
using GStation.Persistence.Repositories.Interfaces;
using GStation.Props.Constants;
using GStation.Services.Interfaces;

namespace GStation.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAuthService _authService;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository, IAuthService authService)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _authService = authService;
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
