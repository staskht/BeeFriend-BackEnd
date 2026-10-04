using BeeFriend.Core.Application.DTO.Interfaces;
using BeeFriend.Core.Application.DTO.UserProfileDTOs;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts.Getters;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface IUserProfilesService :
        IGetAllService<UserProfileResponse>,
        IGetByIdService<UserProfileResponse, Guid>,
        IDeleterService<Guid>
    {
        Task<Result<UserProfileResponse>> UpdateAsync(
            Guid id, 
            JsonPatchDocument<UserProfilePatchRequest> patchDocument, 
            CancellationToken cancellationToken);
    }
}
