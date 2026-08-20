using BeeFriend.Core.Results;

namespace BeeFriend.Core.ServiceContracts.CrudServiceContracts
{
    public interface IDeleterService<Tkey>
        where Tkey : struct
    {
        Task<Result> DeleteByIdAsync(Tkey id);
    }
}
