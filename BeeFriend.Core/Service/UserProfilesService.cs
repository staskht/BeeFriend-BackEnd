using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Core.DTO;
using BeeFriend.Core.Mappers;
using BeeFriend.Core.ServiceContracts;


namespace BeeFriend.Core.Service
{
    public class UserProfilesService : IUserProfilesService
    {
        private readonly IUserProfilesRepository _userProfilesRepository;

        public UserProfilesService(IUserProfilesRepository userProfilesRepository)
        {
            _userProfilesRepository = userProfilesRepository;
        }

        public async Task<IEnumerable<UserProfileResponse>> GetAllAsync()
        {
            var userProfiles = 
                await _userProfilesRepository.GetAllAsync();

            return userProfiles
                .Select(u => u.ToDto())
                .ToList();
        }

        public async Task<UserProfileResponse?> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException(nameof(id), "Id cannot be empty.");

            UserProfile? userProfile = 
                await _userProfilesRepository.GetByIdAsync(id);

            return userProfile?.ToDto();

        }

        public async Task<UserProfileResponse?> UpdateAsync(Guid id, UserProfileUpdateRequest userProfileUpdateRequest)
        {
            if (id == Guid.Empty)
                throw new ArgumentOutOfRangeException(nameof(id), "Id cannot be empty.");

            if (userProfileUpdateRequest == null)
                throw new ArgumentNullException(nameof(userProfileUpdateRequest));

            UserProfile? matchingUserProfile = 
                await _userProfilesRepository.GetByIdAsync(id);

            if (matchingUserProfile == null)
                return null;

            matchingUserProfile.CityId = userProfileUpdateRequest.CityId;
            matchingUserProfile.CountryId = userProfileUpdateRequest.CountryId;
            matchingUserProfile.FirstName = userProfileUpdateRequest.FirstName;
            matchingUserProfile.Bio = userProfileUpdateRequest.Bio;
            matchingUserProfile.Gender = userProfileUpdateRequest.Gender;
            matchingUserProfile.Pronouns = userProfileUpdateRequest.Pronouns;
            matchingUserProfile.Interests = userProfileUpdateRequest.Interests;

            UserProfile updatedUserProfile = 
                await _userProfilesRepository.UpdateAsync(matchingUserProfile);

            return updatedUserProfile.ToDto();
        }
    }
}
