using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts
{
    public interface IDeleterRepository<TKey>
    {
        Task<bool> DeleteByIdAsync(TKey id);
    }
}
