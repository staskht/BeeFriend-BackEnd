using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.UnitOfWorkContract;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using BeeFriend.Core.Domain.IdentityEntities;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.ServiceContracts;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Exceptions;


namespace BeeFriend.Core.Application.Service
{
    public class UserProfilesService : IUserProfilesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserProfilesService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            UserManager<ApplicationUser> userManager
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Result> DeleteByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                return Errors.EmptyGuid(nameof(id));

            ApplicationUser? user =
                await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
                return Errors.UserNotFound;

            IdentityResult result =
                await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                throw new UserDeletionFailedException(string.Join(
                    " | ",
                    result.Errors.Select(e => e.Description)));
            }
            await _unitOfWork.CommitAsync();

            return Result.Success();
        }

        public async Task<Result<IEnumerable<UserProfileResponse>>> GetAllAsync()
        {
            var userProfiles = await _unitOfWork.UserProfiles.GetAllAsync();

            return _mapper.Map<List<UserProfileResponse>>(userProfiles);
        }

        public async Task<Result<UserProfileResponse>> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                return Errors.EmptyGuid(nameof(id));

            UserProfile? userProfile =
                await _unitOfWork.UserProfiles.GetByIdAsync(id);

            if (userProfile == null)
                return Errors.UserNotFound;

            return _mapper.Map<UserProfileResponse>(userProfile);
        }

        public async Task<Result<UserProfileResponse>> UpdateAsync(
            Guid id,
            UserProfileUpdateRequest userProfileUpdateRequest)
        {
            if (id == Guid.Empty)
                return Errors.EmptyGuid(nameof(id));

            ArgumentNullException.ThrowIfNull(userProfileUpdateRequest);

            UserProfile? matchingUserProfile =
                await _unitOfWork.UserProfiles.GetByIdAsync(id);

            if (matchingUserProfile == null)
                return Errors.UserNotFound;

            _mapper.Map(userProfileUpdateRequest, matchingUserProfile);

            var interestIds = userProfileUpdateRequest.InterestIds;
            var personalityTraitsIds = userProfileUpdateRequest.PersonalityTraitsIds;
            var friendshipPreferencesIds = userProfileUpdateRequest.FriendshipPreferencesIds;

            var populationOperations = new Func<Task>[]
            {
                () => PopulateCollection(
                    interestIds,
                    _unitOfWork.Interests.GetAllByIdAsync,
                    matchingUserProfile.Interests),

                () => PopulateCollection(
                    personalityTraitsIds,
                    _unitOfWork.PersonalityTraits.GetAllByIdAsync,
                    matchingUserProfile.PersonalityTraits),

                () => PopulateCollection(
                    friendshipPreferencesIds,
                    _unitOfWork.FriendshipPreferences.GetAllByIdAsync,
                    matchingUserProfile.FriendshipPreferences)
            };

            foreach (var update in populationOperations)
                await update();

            UserProfile updatedUserProfile =
                _unitOfWork.UserProfiles.Update(matchingUserProfile);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<UserProfileResponse>(updatedUserProfile);
        }

        private async Task PopulateCollection<TEntity>
            (IEnumerable<int>? collectionOfIds, 
            Func<IEnumerable<int>, Task<IReadOnlyList<TEntity>>> func,
            ICollection<TEntity> originalCollection)
        {
            if (collectionOfIds != null)
            {
                var currentProfileEntities = await func(collectionOfIds);
                originalCollection.Clear();

                foreach (var entity in currentProfileEntities)
                {
                    originalCollection.Add(entity);
                }
            }
        }

    }
}
