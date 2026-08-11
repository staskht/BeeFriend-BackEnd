using BeeFriend.Core.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.UnitOfWorkContract
{
    public interface IUnitOfWork
    {
        IUserProfileRepository UserProfiles {  get; }
        Task CommitAsync();
    }
}
