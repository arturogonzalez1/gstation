using GStation.Core.Models;
using GStation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GStation.Api.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("states/{countryId}")]
        public async Task<ActionResult<Response<List<State>>>> GetStatesByCountryId(Guid countryId)
        {
            var states = await _locationService.GetStatesByCountryId(countryId);

            var response = new Response<List<State>>();
            response.Data = states;

            return response;
        }

        [HttpGet("countries")]
        public async Task<ActionResult<Response<List<Country>>>> GetCountries()
        {
            var countries = await _locationService.GetCountries();

            var response = new Response<List<Country>>();
            response.Data = countries;

            return response;
        }

    }
}
