using BeeFriend.Core.Application.DTO.InterestDTOs;
using BeeFriend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Application.DTO
{
    public record InterestsWithCategoriesResponse(
        int CategoryId,
        string Name,
        IEnumerable<InterestResponse> Interests
        );
}