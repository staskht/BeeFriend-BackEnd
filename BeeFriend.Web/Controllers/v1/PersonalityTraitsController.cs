using Asp.Versioning;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PersonalityTraitsController : 
        CustomControllerBase

    {
        private readonly IGetterService<PersonalityResponse> _getterService;

        public PersonalityTraitsController(IGetterService<PersonalityResponse> getterService)
        {
            _getterService = getterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalityResponse>>> GetAll()
        {
            var personalityTraaits = await _getterService.GetAllAsync();

            return ReturnResponse(personalityTraaits, Ok);
        }
    }
}
