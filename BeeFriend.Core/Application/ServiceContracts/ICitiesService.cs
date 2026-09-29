using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts.Getters;
using BeeFriend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface ICitiesService : 
        IGetByIdService<City, int>
       
    {
        Task<Result<IEnumerable<CityResponse>>> GetAllByIdAsync(int id);
    }
}
