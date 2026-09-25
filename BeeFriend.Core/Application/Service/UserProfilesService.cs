using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.UnitOfWorkContract;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using BeeFriend.Core.Domain.IdentityEntities;
using BeeFriend.Core.Application.ServiceContracts;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Exceptions;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts.Getters;
using BeeFriend.Core.Application.DTO.UserProfileDTOs;


namespace BeeFriend.Core.Application.Service
{
    public class UserProfilesService : 
        IUserProfilesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserProfilesRepository _userProfilesGetterRepository;
        private readonly IGetAllByIdsRepository<Interest, int> _interestGetter;
        private readonly IGetAllByIdsRepository<Personality, int> _personalityGetter;
        private readonly IGetAllByIdsRepository<FriendshipPreference, int> _friendhipPreferencesGetter;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserProfilesService(
            IUnitOfWork unitOfWork,
            IGetAllByIdsRepository<Interest, int> interestsGetter,
            IGetAllByIdsRepository<Personality, int> personalityGetter,
            IGetAllByIdsRepository<FriendshipPreference, int> friendhipPreferencesGetter,
            IMapper mapper,
            IUserProfilesRepository userProfilesGetterRepository,
            UserManager<ApplicationUser> userManager
            )
        {
            _unitOfWork = unitOfWork;
            _interestGetter = interestsGetter;
            _personalityGetter = personalityGetter;
            _friendhipPreferencesGetter = friendhipPreferencesGetter;
            _mapper = mapper;
            _userProfilesGetterRepository = userProfilesGetterRepository;
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
            var userProfiles = await _userProfilesGetterRepository.GetAllAsync();

            return _mapper.Map<List<UserProfileResponse>>(userProfiles);
        }

        public async Task<Result<UserProfileResponse>> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                return Errors.EmptyGuid(nameof(id));

            UserProfile? userProfile =
                await _userProfilesGetterRepository.GetByIdAsync(id);

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
                await _userProfilesGetterRepository.GetByIdAsync(id);

            if (matchingUserProfile == null)
                return Errors.UserNotFound;

            _mapper.Map(userProfileUpdateRequest, matchingUserProfile);

            var interestIds = userProfileUpdateRequest.InterestIds;
            var personalityTraitsIds = userProfileUpdateRequest.PersonalityTraitsIds;
            var friendshipPreferencesIds = userProfileUpdateRequest.FriendshipPreferencesIds;

            var populationOperations = new Func<Task<Result>>[]
            {
                () => PopulateCollection(
                    interestIds,
                    _interestGetter.GetAllByIdsAsync,
                    matchingUserProfile.Interests,
                    nameof(Interest.InterestId)
                    ),

                () => PopulateCollection(
                    personalityTraitsIds,
                    _personalityGetter.GetAllByIdsAsync,
                    matchingUserProfile.PersonalityTraits,
                    nameof(Personality.PerosnalityId)
                    ),

                () => PopulateCollection(
                    friendshipPreferencesIds,
                    _friendhipPreferencesGetter.GetAllByIdsAsync,
                    matchingUserProfile.FriendshipPreferences,
                    nameof(FriendshipPreference.PreferenceId)
                    )
            };

            foreach (var update in populationOperations)
            {
                var result = await update();

                if (result.IsFailure)
                    return result.Error!;
            }
            
            _userProfilesGetterRepository.Update(matchingUserProfile);

            await _unitOfWork.CommitAsync();

            UserProfile? userProfileWithDetails = 
                await _userProfilesGetterRepository.GetByIdAsync(id);

            return _mapper.Map<UserProfileResponse>(userProfileWithDetails);
        }

        private async Task<Result> PopulateCollection<TEntity>
            (IEnumerable<int>? collectionOfIds, 
            Func<IEnumerable<int>, string, Task<IReadOnlyList<TEntity>>> func,
            ICollection<TEntity> originalCollection,
            string idPropertyName)
        {
            if (collectionOfIds != null)
            {
                var ids = collectionOfIds.ToHashSet();

                var entitiesFromIds = await func(ids, idPropertyName);

                if (ids.Count != entitiesFromIds.Count)
                    return Errors.InvalidId($"{idPropertyName}", "Among the collection an invalid id was sent.");

                originalCollection.Clear();

                foreach (var entity in entitiesFromIds)
                {
                    originalCollection.Add(entity);
                }
            }

            return Result.Success();
        }

    }
}
