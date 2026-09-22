using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts.Getters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface ICrudService<TRequest, TResponse, TKey>: 
        IGetAllService<TResponse>,
        IGetByIdService<TResponse, TKey>,
        ICreatorService<TRequest, TResponse>,
        IDeleterService<TKey>,
        IUpdaterService<TResponse, TRequest, TKey>

        where TRequest : class
        where TResponse : class
        where TKey : struct
    {

    }
}
