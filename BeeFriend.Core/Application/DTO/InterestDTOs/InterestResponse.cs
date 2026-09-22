using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Application.DTO.InterestDTOs
{
    public record InterestResponse(
        int InterestId,
        int CategoryId,
        string Name);

}
