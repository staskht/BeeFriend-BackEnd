using Asp.Versioning;
using BeeFriend.Core.Results;
using BeeFriend.Core.DTO;
using BeeFriend.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UsersController : CustomControllerBase
    {
        private readonly IUserProfilesService _userProfilesService;
        public UsersController(IUserProfilesService userProfilesService) 
        {
            _userProfilesService = userProfilesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfileResponse>>> GetAllMatchingUsers() 
        {
            var matchingUsers = 
                await _userProfilesService.GetAllAsync();

            return matchingUsers.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileResponse>> GetUserProfile(Guid id)
        {
            Result<UserProfileResponse> result = 
                await _userProfilesService.GetByIdAsync(id);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserProfileResponse>> PutUserProfile(Guid id, 
            UserProfileUpdateRequest userProfileUpdateRequest)
        {
            Result<UserProfileResponse> result = 
                await _userProfilesService.UpdateAsync(id, userProfileUpdateRequest);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }
    }
}
