

namespace BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts
{
    public interface ICreatorRepository<TEntity>
        where TEntity : class
    {
        Task AddAsync(TEntity entity);
    }
}
