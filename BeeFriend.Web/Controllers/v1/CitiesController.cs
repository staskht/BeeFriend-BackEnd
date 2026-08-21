using Asp.Versioning;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]

    public class CitiesController : CustomControllerBase
    {
        private readonly IAllReaderService<CityResponse, int> _allReaderService;

        public CitiesController(IAllReaderService<CityResponse, int> allReaderService)
        {
            _allReaderService = allReaderService;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<CityResponse>>> GetAll(int id)
        {
            var cities = await _allReaderService.GetAllAsync(id);

            return ReturnResponse(cities, value => Ok(value));
        }
    }
}
