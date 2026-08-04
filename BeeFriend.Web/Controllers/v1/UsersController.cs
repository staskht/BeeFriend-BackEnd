using Asp.Versioning;
using BeeFriend.Core.Domain.IdentityEntities;
using BeeFriend.Core.DTO;
using BeeFriend.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UsersController : CustomControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserProfilesService _userProfilesService;
        public UsersController(UserManager<ApplicationUser> userManager, IUserProfilesService userProfilesService) 
        {
            _userManager = userManager;
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
            if (id == Guid.Empty)
                return BadRequest("Invalid user id.");

            UserProfileResponse? userProfileResponse = 
                await _userProfilesService.GetByIdAsync(id);

            if (userProfileResponse == null)
                return NotFound("User id was not found");

            return userProfileResponse;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserProfileResponse>> PutUserProfile(Guid id, 
            [FromBody] UserProfileUpdateRequest userProfileUpdateRequest)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid user id.");

            UserProfileResponse? userProfileResponse = 
                await _userProfilesService.GetByIdAsync(id);

            if (userProfileResponse == null)
                return NotFound("User id was not found");

            UserProfileResponse? updatedUserProfile = 
                await _userProfilesService.UpdateAsync(id, userProfileUpdateRequest);

            return updatedUserProfile!;
        }
    }
}
