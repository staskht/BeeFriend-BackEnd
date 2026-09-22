using BeeFriend.Core.Domain.Entities;

namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface ICitiesRepository
    {
        Task<IReadOnlyList<City>> GetAllByIdAsync(int id);
    }
}
