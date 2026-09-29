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
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts.Getters;
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

            var locationResult = await ValidateLocationAsync(
                userProfileUpdateRequest.CountryId, 
                userProfileUpdateRequest.CityId, 
                matchingUserProfile);

            if (locationResult.IsFailure)
                return locationResult.Error!;

            if (userProfileUpdateRequest.CountryId.HasValue && 
                matchingUserProfile.CityId.HasValue &&
                !userProfileUpdateRequest.CityId.HasValue)
            {
                matchingUserProfile.CityId = null;
            }

            if (!EnumValidator.IsValidEnum(userProfileUpdateRequest.Pronouns))
                return Errors.Validation("InvalidPronoun", "Supplied Pronoun value is invalid.");

            if (!EnumValidator.IsValidEnum(userProfileUpdateRequest.Gender))
                return Errors.Validation("InvalidGender", "Supplied Gender value is invalid.");

            _mapper.Map(userProfileUpdateRequest, matchingUserProfile);

            var resultFromCollectionUpdates = await UpdateCollectionAsync(
                userProfileUpdateRequest, matchingUserProfile);

            if (resultFromCollectionUpdates.IsFailure)
                return resultFromCollectionUpdates.Error!;
            
            _userProfilesGetterRepository.Update(matchingUserProfile);

            await _unitOfWork.CommitAsync();

            UserProfile? userProfileWithDetails = 
                await _userProfilesGetterRepository.GetByIdAsync(id);

            return _mapper.Map<UserProfileResponse>(userProfileWithDetails);
        }

        private async Task<Result> ValidateLocationAsync(
            int? requestedCountryId, 
            int? requestedCityId, 
            UserProfile existingUser)
        {
            int? effectiveCountryId = requestedCountryId ?? existingUser.CountryId;

            if (requestedCountryId.HasValue)
            {
                var countryResult = await _countriesService.GetByIdAsync(
                    requestedCountryId.Value);

                if (countryResult.IsFailure)
                    return countryResult.Error!;
            }

            if (requestedCityId.HasValue)
            {
                if (!effectiveCountryId.HasValue)
                    return Errors.Validation("MissingCountryId", "City cannot be assigned before country!");

                var cityResult = await _citysService.GetByIdAsync(requestedCityId.Value);

                if (cityResult.IsFailure)
                    return cityResult.Error!;

                if (cityResult.Value!.CountryId != effectiveCountryId.Value)
                    return Errors.Validation("CountryIdAndCityIdDontMatch", "City not in the correct country.");
            }

            return Result.Success();
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

                if (ids.Count == 0)
                {
                    originalCollection.Clear();
                    return Result.Success();
                }
                    
                var entitiesFromIds = await func(ids, idPropertyName);

                if (ids.Count != entitiesFromIds.Count)
                    return Errors.InvalidId($"{collectionOfIds}", "Among the collection an invalid id was sent.");

                originalCollection.Clear();

                foreach (var entity in entitiesFromIds)
                {
                    originalCollection.Add(entity);
                }
            }

            return Result.Success();
        }

        private async Task<Result>UpdateCollectionAsync(
            UserProfileUpdateRequest request, 
            UserProfile user)
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
                    nameof(Interest.Id)
                    ),

                () => PopulateCollection(
                    personalityTraitsIds,
                    _personalityGetter.GetAllByIdsAsync,
                    user.PersonalityTraits,
                    nameof(Personality.Id)
                    ),

                () => PopulateCollection(
                    friendshipPreferencesIds,
                    _friendhipPreferencesGetter.GetAllByIdsAsync,
                    user.FriendshipPreferences,
                    nameof(FriendshipPreference.Id)
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
