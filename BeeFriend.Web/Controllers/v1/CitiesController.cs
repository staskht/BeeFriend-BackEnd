using Asp.Versioning;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]

    public class CitiesController : CustomControllerBase
    {
        private readonly IAllGetterByIdService<CityResponse, int> _allReaderService;

        public CitiesController(IAllGetterByIdService<CityResponse, int> allReaderService)
        {
            _allReaderService = allReaderService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<CityResponse>>> GetAll(int id)
        {
            var cities = await _allReaderService.GetAllByIdAsync(id);

            return ReturnResponse(cities, Ok);
        }
    }
}
