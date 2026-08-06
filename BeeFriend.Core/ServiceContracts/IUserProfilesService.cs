using BeeFriend.Core.Domain.IdentityEntities;
using BeeFriend.Core.DTO;


namespace BeeFriend.Core.ServiceContracts
{
    public interface IUserProfilesService 

    {
        Task<bool> CreateAsync(ApplicationUser entity);

        Task<bool> DeleteByIdAsync(Guid id);

        Task<UserProfileResponse?> GetByIdAsync(Guid id);

        Task<IEnumerable<UserProfileResponse>> GetAllAsync();

        Task<UserProfileResponse?> UpdateAsync(Guid key, UserProfileUpdateRequest request);


    }
}
