using BeeFriend.Core.Domain.Entities;


namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface IUserProfilesRepository
    {
        Task CreateAsync(UserProfile profile);

        Task<bool> DeleteByIdAsync(Guid id);

        Task<UserProfile?> GetByIdAsync(Guid id);

        Task<IReadOnlyList<UserProfile>> GetAllAsync();

        Task<UserProfile> UpdateAsync(UserProfile entity);

    }
}
