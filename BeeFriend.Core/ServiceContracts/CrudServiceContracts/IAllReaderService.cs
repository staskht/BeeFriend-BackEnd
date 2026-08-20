using BeeFriend.Core.Results;

namespace BeeFriend.Core.ServiceContracts.CrudServiceContracts
{
    public interface IAllReaderService<TResponse>
        where TResponse : class
    {
        Task<Result<IEnumerable<TResponse>>> GetAllAsync();

    }

    public interface IAllReaderService<TResponse, TKey>
        where TResponse : class
        where TKey : struct
    {
        Task<Result<IEnumerable<TResponse>>> GetAllAsync(TKey key);
    }
}
