using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts.Getters;

namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface ICitiesRepository : 
        IGetByIdRepository<City, int>
    {
        Task<IReadOnlyList<City>> GetAllByIdAsync(int id);
    }
}
