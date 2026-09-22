namespace BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts.Getters
{
    public interface IGetAllByIdsRepository<TEntity, TKey>
       where TEntity : class
       where TKey : struct
    {
        Task<IReadOnlyList<TEntity>> GetAllByIdsAsync(IEnumerable<TKey> keys, string idPropertyName);
    }
}
