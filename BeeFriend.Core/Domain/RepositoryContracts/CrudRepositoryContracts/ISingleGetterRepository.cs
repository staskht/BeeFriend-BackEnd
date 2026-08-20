using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts
{
    public interface ISingleGetterRepository<TEntity, TKey>
        where TEntity : class?
        where TKey : struct
    {
        Task<TEntity?> GetByIdAsync(TKey id);
    }
}
