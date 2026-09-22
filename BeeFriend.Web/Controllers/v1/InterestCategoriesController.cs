using Asp.Versioning;
using Azure;
using BeeFriend.Core.Application.DTO.InterestCategoryDTOs;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InterestCategoriesController : 
        CrudController<
            InterestCategoryRequest, 
            InterestCategoryResponse, 
            int, 
            IInterestCategoriesService>
    {
        public InterestCategoriesController(
            IInterestCategoriesService service) 
            : base(service) 
        {
        }

        [HttpGet("categories-with-interests")]
        public async Task<ActionResult<IEnumerable<InterestCategoryResponse>>> GetAllCategoriesWithInterestsAsync()
        {
            var entities = await _service.GetAllCategoriesWithInterestsAsync();

            return ReturnResponse(entities, Ok);
        }
    }
}
