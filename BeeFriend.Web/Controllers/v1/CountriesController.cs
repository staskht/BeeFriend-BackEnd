using Asp.Versioning;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CountriesController : CustomControllerBase
    {
        private readonly IAllReaderService<CountryResponse> _allReaderService;

        public CountriesController(IAllReaderService<CountryResponse> allReaderService)
        {
            _allReaderService = allReaderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryResponse>>> GettAll()
        {
            var countries = await _allReaderService.GetAllAsync();

            return ReturnResponse(countries, value => Ok(value));
        }
    }
}
