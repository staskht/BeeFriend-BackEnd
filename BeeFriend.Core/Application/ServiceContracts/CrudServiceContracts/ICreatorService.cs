using BeeFriend.Core.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts
{
    public interface ICreatorService<TRequest,  TResponse>
    {
        Task<Result<TResponse>> AddAsync(TRequest requestDto);
    }
}
