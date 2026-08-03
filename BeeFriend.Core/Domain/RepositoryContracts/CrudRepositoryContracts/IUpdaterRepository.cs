using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts
{
    public interface IUpdaterRepository<TEntity>
    {
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
