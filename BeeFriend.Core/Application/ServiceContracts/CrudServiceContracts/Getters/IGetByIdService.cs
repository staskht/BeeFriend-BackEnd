using BeeFriend.Core.Application.Results;

namespace BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts.Getters
{
    public interface IGetByIdService<TResponse, Tkey>
        where TResponse : class
        where Tkey : struct
    {
        Task<Result<TResponse>> GetByIdAsync(Tkey id);
    }

}
