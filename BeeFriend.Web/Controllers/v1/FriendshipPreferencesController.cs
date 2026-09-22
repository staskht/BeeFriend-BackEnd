using Asp.Versioning;
using BeeFriend.Core.Application.DTO.FriendshipPreferenceDTOs;
using BeeFriend.Core.Application.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FriendshipPreferencesController : 
        CrudController<
            FriendshipPreferenceRequest, 
            FriendshipPreferenceResponse, 
            int, 
            ICrudService<
                FriendshipPreferenceRequest,
                FriendshipPreferenceResponse,
                int>
            >
    {
        public FriendshipPreferencesController(
            ICrudService<
                FriendshipPreferenceRequest, 
                FriendshipPreferenceResponse, 
                int> service) 
            : base(service) 
        {
        }
    }
}
