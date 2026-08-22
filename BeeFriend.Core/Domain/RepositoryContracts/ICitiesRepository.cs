using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts;

namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface ICitiesRepository:
        IAllGetterRepository<City, int>
    {
        
    }
}
