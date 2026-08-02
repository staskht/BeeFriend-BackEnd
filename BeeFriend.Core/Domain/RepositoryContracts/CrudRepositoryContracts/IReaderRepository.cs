using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts
{
    public interface IReaderRepository<TEntity, TKey>
    {
        Task<TEntity?> GetByIdAsync(TKey id);

        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
