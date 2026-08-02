using BeeFriend.Core.DTO;
using BeeFriend.Core.ServiceContracts.CrudServiceContracts;


namespace BeeFriend.Core.ServiceContracts
{
    public interface IUserProfilesService :
        IReaderService<UserDto, Guid>,
        IUpdaterService<UserDto, UserDto>

    {
        
    }
}
