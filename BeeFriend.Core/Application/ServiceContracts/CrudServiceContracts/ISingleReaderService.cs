using BeeFriend.Core.Application.Results;

namespace BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts
{
    public interface ISingleReaderService<TResponse, Tkey>
        where TResponse : class
        where Tkey : struct
    {
        Task<Result<TResponse>> GetByIdAsync(Tkey id);
    }
}
