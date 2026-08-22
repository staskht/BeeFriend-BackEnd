using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts
{
    public interface IAllGetterRepository<TEntity>
        where TEntity : class
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
    }

    public interface IAllGetterRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        Task<IReadOnlyList<TEntity>> GetAllByIdAsync(TKey key);
    }
}
