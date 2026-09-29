using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts.Getters;
using BeeFriend.Core.Domain.Entities;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface ICountriesService:
        IGetAllService<CountryResponse>,
        IGetByIdService<Country, int>
    {
    }
}
