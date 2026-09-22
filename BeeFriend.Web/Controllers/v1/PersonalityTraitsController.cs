using Asp.Versioning;
using BeeFriend.Core.Application.DTO.PersonalityDTOs;
using BeeFriend.Core.Application.ServiceContracts;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PersonalityTraitsController : 
        CrudController<
            PersonalityRequest, 
            PersonalityResponse, 
            int, 
            ICrudService<
                PersonalityRequest, 
                PersonalityResponse, 
                int>
            >
    {
        public PersonalityTraitsController(
            ICrudService<
                PersonalityRequest, 
                PersonalityResponse, 
                int> service)
            : base(service)
        {
        }
    }
}
