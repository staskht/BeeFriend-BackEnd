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

        public UserProfilesService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
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
            var userProfiles = 
                await _unitOfWork.UserProfiles.GetAllAsync();

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

            matchingUserProfile.CityId = userProfileUpdateRequest.CityId;
            matchingUserProfile.CountryId = userProfileUpdateRequest.CountryId;
            matchingUserProfile.FirstName = userProfileUpdateRequest.FirstName;
            matchingUserProfile.Bio = userProfileUpdateRequest.Bio;
            matchingUserProfile.Gender = userProfileUpdateRequest.Gender;
            matchingUserProfile.Pronouns = userProfileUpdateRequest.Pronouns;

            var interestIds = userProfileUpdateRequest.InterestIds;

            if(interestIds != null)
            {
                var interests = await _unitOfWork.Interests
                    .GetAllByIdAsync(interestIds);

                matchingUserProfile.Interests.Clear();

                foreach(var interest in interests)
                    matchingUserProfile.Interests.Add(interest);
            }
            
            UserProfile updatedUserProfile = 
                _unitOfWork.UserProfiles.Update(matchingUserProfile);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<UserProfileResponse>(updatedUserProfile);
        }
    }
}
