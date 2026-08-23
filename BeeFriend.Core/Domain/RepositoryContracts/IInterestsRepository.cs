using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts;

namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface IInterestsRepository
    {
        Task<IReadOnlyList<Interest>> GetAllByIdAsync(IEnumerable<int> ids);
    }
}
