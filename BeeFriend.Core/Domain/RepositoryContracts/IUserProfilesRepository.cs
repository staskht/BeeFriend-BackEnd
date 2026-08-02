using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts;


namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface IUserProfilesRepository : 
        IReaderRepository<UserProfile, Guid>,
        IUpdaterRepository<UserProfile>
    {
    }
}
