using Asp.Versioning;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.ServiceContracts;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts.Getters;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CountriesController : CustomControllerBase
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryResponse>>> GettAll()
        {
            var countries = await _countriesService.GetAllAsync();

            return ReturnResponse(countries, Ok);
        }
    }
}
