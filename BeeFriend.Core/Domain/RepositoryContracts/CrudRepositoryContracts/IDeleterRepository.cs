using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts
{
    public interface IDeleterRepository<TEntity>
        where TEntity : class
    {
        void Delete(TEntity id);
    }
}
