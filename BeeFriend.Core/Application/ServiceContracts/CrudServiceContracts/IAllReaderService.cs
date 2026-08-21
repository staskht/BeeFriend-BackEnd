using BeeFriend.Core.Application.Results;

namespace BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts
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
