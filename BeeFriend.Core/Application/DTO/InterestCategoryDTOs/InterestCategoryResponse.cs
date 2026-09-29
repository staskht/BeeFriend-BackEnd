using BeeFriend.Core.Application.DTO.InterestDTOs;
using BeeFriend.Core.Application.DTO.Interfaces;

namespace BeeFriend.Core.Application.DTO.InterestCategoryDTOs
{
    public record InterestCategoryResponse(
        int Id,
        string Name) : IResponse<int>;
}
