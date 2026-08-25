using Asp.Versioning;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FriendshipPreferencesController : 
        CustomControllerBase

    {
        private readonly IGetterService<FriendshipPreferenceResponse> _getterService;

        public FriendshipPreferencesController(IGetterService<FriendshipPreferenceResponse> getterService)
        {
            _getterService = getterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendshipPreferenceResponse>>> GetAll()
        {
            var preferences = await _getterService.GetAllAsync();

            return ReturnResponse(preferences, Ok);
        }
    }
}
