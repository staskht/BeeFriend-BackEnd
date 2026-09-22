using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.DTO.InterestDTOs
{
    public record InterestRequest(
        int CategoryId,
        string Name);
}
