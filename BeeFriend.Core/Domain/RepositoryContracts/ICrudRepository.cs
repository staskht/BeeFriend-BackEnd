namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface ICrudRepository<TEntity, Tkey>
        where TEntity : class
    {
        Task CreateAsync(TEntity entity);

        Task DeleteByIdAsync(Tkey id);

        Task<TEntity?> GetByIdAsync(Tkey id);

        Task<IReadOnlyList<TEntity>> GetAllAsync();

        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
