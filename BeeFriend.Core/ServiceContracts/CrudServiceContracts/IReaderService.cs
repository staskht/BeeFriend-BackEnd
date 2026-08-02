

namespace BeeFriend.Core.ServiceContracts.CrudServiceContracts
{
    public interface IReaderService<TEntity, TKey> 
        where TKey : struct
    {
        Task<TEntity?> GetByIdAsync(TKey? id);

        Task<IReadOnlyList<TEntity>> GetAllAsync();
    }
}
