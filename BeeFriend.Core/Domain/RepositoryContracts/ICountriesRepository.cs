using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts.Getters;

namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface ICountriesRepository : 
        IGetAllRepository<Country>,
        IGetByIdRepository<Country, int>
    {
    }
}
