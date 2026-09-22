using Asp.Versioning;
using BeeFriend.Core.Application.DTO.InterestDTOs;
using BeeFriend.Core.Application.ServiceContracts;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InterestsController : 
        CrudController<
            InterestRequest, 
            InterestResponse, 
            int, 
            ICrudService<
                InterestRequest, 
                InterestResponse, 
                int>
            >
    {
        public InterestsController(
            ICrudService<
                InterestRequest, 
                InterestResponse, 
                int> service) 
            : base(service)
        {
        }
    }
}
