using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.ServiceContracts.CrudServiceContracts
{
    public interface IDeleterService<TKey>
    {
        Task<bool> DeleteByIdAsync(TKey id);
    }
}
