using BeeFriend.Core.Application.Results;

namespace BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts.Getters
{
    public interface IGetAllService<TResponse>
        where TResponse : class
    {
        Task<Result<IEnumerable<TResponse>>> GetAllAsync();

    }

}
