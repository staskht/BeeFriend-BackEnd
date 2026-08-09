using BeeFriend.Core.Results;
using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.IdentityEntities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Core.DTO;
using BeeFriend.Core.Enums;
using BeeFriend.Core.Mappers;
using BeeFriend.Core.ServiceContracts;
using BeeFriend.Core.Domain.UnitOfWorkContract;


namespace BeeFriend.Core.Service
{
    public class UserProfilesService : IUserProfilesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserProfilesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Result> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserProfileResponse>> GetAllAsync()
        {
            var userProfiles = 
                await _unitOfWork.UserProfiles.GetAllAsync();

            return userProfiles
                .Select(u => u.ToDto())
                .ToList();
        }

        public async Task<Result<UserProfileResponse>> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                return Errors.EmptyGuid(nameof(id));

            UserProfile? userProfile = 
                await _unitOfWork.UserProfiles.GetByIdAsync(id);

            if (userProfile == null)
                return Errors.UserNotFound;

            return userProfile.ToDto();
        }

        public async Task<Result<UserProfileResponse>> UpdateAsync(Guid id, UserProfileUpdateRequest userProfileUpdateRequest)
        {
            if (id == Guid.Empty)
                return Errors.EmptyGuid(nameof(id));

            ArgumentNullException.ThrowIfNull(userProfileUpdateRequest);

            UserProfile? matchingUserProfile = 
                await _unitOfWork.UserProfiles.GetByIdAsync(id);

            if (matchingUserProfile == null)
                return Errors.UserNotFound;

            matchingUserProfile.CityId = userProfileUpdateRequest.CityId;
            matchingUserProfile.CountryId = userProfileUpdateRequest.CountryId;
            matchingUserProfile.FirstName = userProfileUpdateRequest.FirstName;
            matchingUserProfile.Bio = userProfileUpdateRequest.Bio;
            matchingUserProfile.Gender = userProfileUpdateRequest.Gender;
            matchingUserProfile.Pronouns = userProfileUpdateRequest.Pronouns;
            matchingUserProfile.Interests = userProfileUpdateRequest.Interests;

            UserProfile updatedUserProfile = 
                await _unitOfWork.UserProfiles.UpdateAsync(matchingUserProfile);

            await _unitOfWork.CommitAsync();

            return updatedUserProfile.ToDto();
        }
    }
}
