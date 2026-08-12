using Asp.Versioning;
using BeeFriend.Core.Results;
using BeeFriend.Core.DTO;
using BeeFriend.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

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
        public async Task<ActionResult<IEnumerable<UserProfileResponse>>> GetAll() 
        {
            var matchingUsers = 
                await _userProfilesService.GetAllAsync();

            return matchingUsers.ToList();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserProfileResponse>> GetUserProfile(Guid id)
        {
            Result<UserProfileResponse> result = 
                await _userProfilesService.GetByIdAsync(id);

            return ReturnResponse(result, value => Ok(value));
            
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult<UserProfileResponse>> PatchUserProfile(
            Guid id, 
            UserProfileUpdateRequest userProfileUpdateRequest)
        {

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id.ToString() != currentUserId) 
            {
                return Forbid();
            }

            Result<UserProfileResponse> result = 
                await _userProfilesService.UpdateAsync(id, userProfileUpdateRequest);

            return ReturnResponse(result, value => Ok(value));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteUserProfile(Guid id)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id.ToString() != currentUserId)
            {
                return Forbid();
            }

            Result result = await _userProfilesService.DeleteByIdAsync(id);

            return ReturnResponse(result, () => NoContent());
        }
    }
}
