namespace BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts.Getters
{
    public interface IGetByIdRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        Task<TEntity?> GetByIdAsync(TKey id);
    }
}
