using BeeFriend.Core.Application.Results;

namespace BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts
{
    public interface IUpdaterService<TResponse, TRequest, TKey>
    {
        Task<Result<TResponse>> UpdateAsync(TKey key, TRequest request);
    }
}
