using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts.Getters;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface ICountriesService:
        IGetAllService<CountryResponse>
    {
        Task<Result> ExistsAsync(int countryId);
    }
}
