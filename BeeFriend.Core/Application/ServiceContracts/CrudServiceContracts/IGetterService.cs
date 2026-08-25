using BeeFriend.Core.Application.Results;

namespace BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts
{
    public interface IGetterService<TResponse>
        where TResponse : class
    {
        Task<Result<IEnumerable<TResponse>>> GetAllAsync();

    }

    public interface IAllGetterByIdService<TResponse, TKey>
        where TResponse : class
        where TKey : struct
    {
        Task<Result<IEnumerable<TResponse>>> GetAllByIdAsync(TKey key);
    }

    public interface ISingleGetterService<TResponse, Tkey>
        where TResponse : class
        where Tkey : struct
    {
        Task<Result<TResponse>> GetByIdAsync(Tkey id);
    }
}
