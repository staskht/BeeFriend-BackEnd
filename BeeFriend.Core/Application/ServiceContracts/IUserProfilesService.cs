using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface IUserProfilesService :
        IGetterService<UserProfileResponse>,
        ISingleGetterService<UserProfileResponse, Guid>,
        IDeleterService<Guid>,
        IUpdaterService<UserProfileResponse, UserProfileUpdateRequest, Guid>

    {
    }
}
