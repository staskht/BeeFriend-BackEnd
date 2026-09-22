using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts
{
    public interface IUpdaterRepository<TEntity>
        where TEntity : class
    {
        void Update(TEntity entity);
    }
}
