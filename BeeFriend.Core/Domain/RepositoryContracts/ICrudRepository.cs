namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface ICrudRepository<TEntity, Tkey>
        where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        void Delete(TEntity id);
        Task<TEntity?> GetByIdAsync(Tkey id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        TEntity Update(TEntity entity);
    }
}
