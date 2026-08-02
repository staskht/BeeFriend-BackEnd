using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts
{
    public interface ICreatorRepository<TEntity>
    {
        Task<TEntity> CreateAsync(TEntity entity);
    }
}
