using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface IUserProfilesRepository : 
        ICreatorRepository<UserProfile>,
        IAllGetterRepository<UserProfile>,
        ISingleGetterRepository<UserProfile, Guid>,
        IUpdaterRepository<UserProfile>
    {
    }
}
