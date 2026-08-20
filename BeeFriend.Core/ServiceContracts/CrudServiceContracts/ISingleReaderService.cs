using BeeFriend.Core.Results;

namespace BeeFriend.Core.ServiceContracts.CrudServiceContracts
{
    public interface ISingleReaderService<TResponse, Tkey>
        where TResponse : class
        where Tkey : struct
    {
        Task<Result<TResponse>> GetByIdAsync(Tkey id);
    }
}
