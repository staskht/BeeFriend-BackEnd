using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts.Getters;


namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface IUserProfilesRepository : 
        ICreatorRepository<UserProfile>,
        IGetAllRepository<UserProfile>,
        IGetByIdRepository<UserProfile, Guid>,
        IUpdaterRepository<UserProfile>
    {
    }
}
