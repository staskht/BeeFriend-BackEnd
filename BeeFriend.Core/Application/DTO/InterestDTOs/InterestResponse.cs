using BeeFriend.Core.Application.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Application.DTO.InterestDTOs
{
    public record InterestResponse(
        int Id,
        int CategoryId,
        string Name) : IResponse<int>;

}
