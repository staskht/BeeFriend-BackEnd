using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface ICitiesReader
    {
        Task<Result<IEnumerable<CityResponse>>> GetAllByIdAsync(int id);
    }
}
