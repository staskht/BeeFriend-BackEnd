using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts
{
    public interface ICreatorRepository<TEntity>
        where TEntity : class
    {
        Task CreateAsync(TEntity entity);
    }
}
