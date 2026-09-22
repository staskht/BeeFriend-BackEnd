using BeeFriend.Core.Application.DTO.UserProfileDTOs;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts.Getters;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface IUserProfilesService :
        IGetAllService<UserProfileResponse>,
        IGetByIdService<UserProfileResponse, Guid>,
        IDeleterService<Guid>,
        IUpdaterService<UserProfileResponse, UserProfileUpdateRequest, Guid>

    {
    }
}
