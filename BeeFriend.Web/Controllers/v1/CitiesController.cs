using Asp.Versioning;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.ServiceContracts;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]

    public class CitiesController : CustomControllerBase
    {
        private readonly ICitiesReader _citiesReader;

        public CitiesController(ICitiesReader citiesReader)
        {
            _citiesReader = citiesReader;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<CityResponse>>> GetAll(int id)
        {
            var cities = await _citiesReader.GetAllByIdAsync(id);

            return ReturnResponse(cities, Ok);
        }
    }
}
