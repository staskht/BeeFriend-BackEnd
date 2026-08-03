using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.ServiceContracts.CrudServiceContracts
{
    public interface IUpdaterService<TRequest, TResponse>
    {
        Task<TResponse?> UpdateAsync(TRequest request);
    }
}
