using BeeFriend.Core.DTO;
using BeeFriend.Core.ServiceContracts.CrudServiceContracts;


namespace BeeFriend.Core.ServiceContracts
{
    public interface IUserProfilesService :
        IAllReaderService<UserProfileResponse>,
        ISingleReaderService<UserProfileResponse, Guid>,
        IDeleterService<Guid>,
        IUpdaterService<UserProfileResponse, UserProfileUpdateRequest, Guid>

    {
    }
}
