using BeeFriend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface IUserProfileRepository : 
        ICrudRepository<UserProfile, Guid>
    {
    }
}
