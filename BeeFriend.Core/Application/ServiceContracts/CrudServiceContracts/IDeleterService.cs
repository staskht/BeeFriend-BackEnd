using BeeFriend.Core.Application.Results;

namespace BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts
{
    public interface IDeleterService<Tkey>
        where Tkey : struct
    {
        Task<Result> DeleteByIdAsync(Tkey id);
    }
}
