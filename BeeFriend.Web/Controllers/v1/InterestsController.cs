using Asp.Versioning;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InterestsController : 
        CustomControllerBase
    {
        private readonly IGetterService<InterestsWithCategoriesResponse> _getterService;

        public InterestsController(IGetterService<InterestsWithCategoriesResponse> getterService)
        {
            _getterService = getterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterestsWithCategoriesResponse>>> GetAll() 
        {
            var interests = await _getterService.GetAllAsync();

            return ReturnResponse(interests, Ok);
        }
    }
}
