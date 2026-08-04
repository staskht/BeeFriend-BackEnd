

namespace BeeFriend.Core.ServiceContracts.CrudServiceContracts
{
    public interface IReaderService<TEntity, TKey>      
    {
        Task<TEntity?> GetByIdAsync(TKey id);

        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
