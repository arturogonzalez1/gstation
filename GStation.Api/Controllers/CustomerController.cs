using AutoMapper;
using GStation.Core.Models;
using GStation.Core.Models.DTOs;
using GStation.Props.Constants;
using GStation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GStation.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        private readonly IAuthService _authService;
        private readonly ILocationService _locationService;

        public CustomerController(IMapper mapper, ICustomerService customerService, IAuthService authService, ILocationService locationService)
        {
            _mapper = mapper;
            _customerService = customerService;
            _authService = authService;
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            return await _customerService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomerSignupDto customerSignupDto)
        {
            foreach (var address in customerSignupDto.Addresses)
            {
                await _locationService.GetStateById(address.StateId);
            }

            var user = _mapper.Map<ApplicationUser>(customerSignupDto);

            await _authService.Signup(user, customerSignupDto.Password, Role.CUSTOMER);

            var customer = _mapper.Map<Customer>(customerSignupDto);
            customer.RemovePerson();
            customer.PersonId = user.PersonId;

            try
            {
                await _customerService.Create(customer);
            }
            catch (Exception)
            {
                await _authService.DeleteUser(user);
                throw;
            }

            return Ok();
        }
    }
}
