namespace BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts.Getters
{
    public interface IGetAllRepository<TEntity>
        where TEntity : class
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
    }
}
