using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Core.DTO;
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

        public Task<IReadOnlyList<UserDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto?> GetByIdAsync(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            UserProfile? userProfile = await _userProfilesRepository.GetByIdAsync(id.Value);

            if (userProfile == null) 
            {
                return null;
            }

            return null; // temporary fix with dto later

        }

        public Task<UserDto?> UpdateAsync(UserDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
