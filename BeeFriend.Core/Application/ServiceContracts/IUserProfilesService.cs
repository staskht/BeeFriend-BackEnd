using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface IUserProfilesService :
        IAllReaderService<UserProfileResponse>,
        ISingleReaderService<UserProfileResponse, Guid>,
        IDeleterService<Guid>,
        IUpdaterService<UserProfileResponse, UserProfileUpdateRequest, Guid>

    {
    }
}
