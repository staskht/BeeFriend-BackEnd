namespace BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts
{
    public interface IGetterRepository<TEntity>
        where TEntity : class
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
    }

    public interface ISingleGetterByIdRepository<TEntity, TKey>
        where TEntity : class?
        where TKey : struct
    {
        Task<TEntity?> GetByIdAsync(TKey id);
    }

    public interface IAllGetterByIdsRepository<TEntity, TKey>
       where TEntity : class
       where TKey : struct
    {
        Task<IReadOnlyList<TEntity>> GetAllByIdAsync(IEnumerable<TKey> keys);
    }
}
