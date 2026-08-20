using BeeFriend.Core.Results;

namespace BeeFriend.Core.ServiceContracts.CrudServiceContracts
{
    public interface IUpdaterService<TResponse, TRequest, TKey>
    {
        Task<Result<TResponse>> UpdateAsync(TKey key, TRequest request);
    }
}
