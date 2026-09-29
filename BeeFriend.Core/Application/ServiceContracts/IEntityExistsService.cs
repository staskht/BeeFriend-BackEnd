using BeeFriend.Core.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface IEntityExistsService<TEntity>
    {
        Task<Result<TEntity>> ExistsAsync(int id);
    }
}
