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
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;
using BeeFriend.Core.Application.Helpers;


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
        private readonly ICountriesService _countriesService;
        private readonly ICitiesService _citysService;
        public UserProfilesService(
            IUnitOfWork unitOfWork,
            IGetAllByIdsRepository<Interest, int> interestsGetter,
            IGetAllByIdsRepository<Personality, int> personalityGetter,
            IGetAllByIdsRepository<FriendshipPreference, int> friendhipPreferencesGetter,
            IMapper mapper,
            IUserProfilesRepository userProfilesGetterRepository,
            UserManager<ApplicationUser> userManager,
            ICountriesService countriesService,
            ICitiesService citysService
            )
        {
            _unitOfWork = unitOfWork;
            _interestGetter = interestsGetter;
            _personalityGetter = personalityGetter;
            _friendhipPreferencesGetter = friendhipPreferencesGetter;
            _mapper = mapper;
            _userProfilesGetterRepository = userProfilesGetterRepository;
            _userManager = userManager;
            _countriesService = countriesService;
            _citysService = citysService;
        }

        public async Task<Result> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
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
            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success();
        }

        public async Task<Result<IEnumerable<UserProfileResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var userProfiles = await _userProfilesGetterRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<List<UserProfileResponse>>(userProfiles);
        }

        public async Task<Result<UserProfileResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty)
                return Errors.EmptyGuid(nameof(id));

            UserProfile? userProfile =
                await _userProfilesGetterRepository.GetByIdAsync(id, cancellationToken);

            if (userProfile == null)
                return Errors.UserNotFound;

            return _mapper.Map<UserProfileResponse>(userProfile);
        }

        public async Task<Result<UserProfileResponse>> UpdateAsync(
            Guid id,
            JsonPatchDocument<UserProfilePatchRequest> patchDocument,
            CancellationToken cancellationToken)
        {
            if (id == Guid.Empty)
                return Errors.EmptyGuid(nameof(id));

            ArgumentNullException.ThrowIfNull(patchDocument);

            UserProfile? matchingUserProfile =
                await _userProfilesGetterRepository.GetByIdAsync(id, cancellationToken);

            if (matchingUserProfile == null)
                return Errors.UserNotFound;

            var userProfilePatchRequest = _mapper.Map<UserProfilePatchRequest>(matchingUserProfile);

            patchDocument.ApplyTo(userProfilePatchRequest);

            bool cityWasChanged = patchDocument.Operations
                .Any(x => x.path.Equals("/cityId", StringComparison.OrdinalIgnoreCase));

            bool countryActuallyChanged =
                matchingUserProfile.CountryId != userProfilePatchRequest.CountryId;

            if (countryActuallyChanged && !cityWasChanged)
            {
                userProfilePatchRequest.CityId = null;
            }

            if (userProfilePatchRequest.CountryId.HasValue)
            {
                var countryResult = await _countriesService.GetByIdAsync(
                    userProfilePatchRequest.CountryId.Value,
                    cancellationToken);

                if (countryResult.IsFailure)
                    return countryResult.Error!;
            }

            if (userProfilePatchRequest.CityId.HasValue)
            {
                var cityResult = await _citysService.GetByIdAsync(
                    userProfilePatchRequest.CityId.Value,
                    cancellationToken);

                if (cityResult.IsFailure)
                    return cityResult.Error!;

                if (!userProfilePatchRequest.CountryId.HasValue)
                    return Errors.Validation(
                        "MissingCountryId",
                        "City cannot be assigned before country!");

                if (cityResult.Value!.CountryId != userProfilePatchRequest.CountryId.Value)
                    return Errors.Validation(
                        "CountryIdAndCityIdDontMatch",
                        "City not in the correct country.");
            }

            if (!EnumValidator.IsValidEnum(userProfilePatchRequest.Pronouns))
                return Errors.Validation("InvalidPronoun", "Supplied Pronoun value is invalid.");

            if (!EnumValidator.IsValidEnum(userProfilePatchRequest.Gender))
                return Errors.Validation("InvalidGender", "Supplied Gender value is invalid.");

            _mapper.Map(userProfilePatchRequest, matchingUserProfile);

            var resultFromCollectionUpdates = await UpdateCollectionAsync(
                userProfilePatchRequest, 
                matchingUserProfile, 
                cancellationToken);

            if (resultFromCollectionUpdates.IsFailure)
                return resultFromCollectionUpdates.Error!;
            
            _userProfilesGetterRepository.Update(matchingUserProfile);

            await _unitOfWork.CommitAsync(cancellationToken);

            UserProfile? userProfileWithDetails = 
                await _userProfilesGetterRepository.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<UserProfileResponse>(userProfileWithDetails);
        }

        private async Task<Result> PopulateCollection<TEntity>
            (IEnumerable<int>? collectionOfIds, 
            Func<IEnumerable<int>, string, CancellationToken, Task<IReadOnlyList<TEntity>>> func,
            ICollection<TEntity> originalCollection,
            string idPropertyName,
            string collecionName,
            CancellationToken cancellationToken)
        {
            if (collectionOfIds != null)
            {
                var ids = collectionOfIds.ToHashSet();

                if (ids.Count == 0)
                {
                    originalCollection.Clear();
                    return Result.Success();
                }
                    
                var entitiesFromIds = await func(ids, idPropertyName, cancellationToken);

                if (ids.Count != entitiesFromIds.Count)
                    return Errors.InvalidId($"{collecionName}", "Among the collection an invalid id was sent.");

                originalCollection.Clear();

                foreach (var entity in entitiesFromIds)
                {
                    originalCollection.Add(entity);
                }
            }

            return Result.Success();
        }

        private async Task<Result>UpdateCollectionAsync(
            UserProfilePatchRequest request, 
            UserProfile user,
            CancellationToken cancellationToken)
        {
            var interestIds = request.InterestIds;
            var personalityTraitsIds = request.PersonalityTraitsIds;
            var friendshipPreferencesIds = request.FriendshipPreferencesIds;

            var populationOperations = new Func<Task<Result>>[]
            {
                () => PopulateCollection(
                    interestIds,
                    _interestGetter.GetAllByIdsAsync,
                    user.Interests,
                    nameof(Interest.Id),
                    nameof(interestIds),
                    cancellationToken
                    ),

                () => PopulateCollection(
                    personalityTraitsIds,
                    _personalityGetter.GetAllByIdsAsync,
                    user.PersonalityTraits,
                    nameof(Personality.Id),
                    nameof(personalityTraitsIds),
                    cancellationToken
                    ),

                () => PopulateCollection(
                    friendshipPreferencesIds,
                    _friendhipPreferencesGetter.GetAllByIdsAsync,
                    user.FriendshipPreferences,
                    nameof(FriendshipPreference.Id),
                    nameof(friendshipPreferencesIds),
                    cancellationToken
                    )
            };

            foreach (var update in populationOperations)
            {
                var result = await update();

                if (result.IsFailure)
                    return result.Error!;
            }

            return Result.Success();
        }


    }
}
