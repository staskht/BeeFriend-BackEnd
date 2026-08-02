

namespace BeeFriend.Core.ServiceContracts.CrudServiceContracts
{
    public interface ICreatorService<TRequest, TResponse>
    {
        Task<TResponse> CreateAsync(TRequest entity);
    }
}
