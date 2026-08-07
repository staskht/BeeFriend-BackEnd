using BeeFriend.Core.Results;
using BeeFriend.Core.Domain.IdentityEntities;
using BeeFriend.Core.DTO;
using BeeFriend.Core.Enums;


namespace BeeFriend.Core.ServiceContracts
{
    public interface IUserProfilesService 

    {
        Task<Result> DeleteByIdAsync(Guid id);

        Task<Result<UserProfileResponse>> GetByIdAsync(Guid id);

        Task<IEnumerable<UserProfileResponse>> GetAllAsync();

        Task<Result<UserProfileResponse>> UpdateAsync(Guid key, UserProfileUpdateRequest request);


    }
}
