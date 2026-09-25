using BeeFriend.Core.Application.DTO.InterestDTOs;

namespace BeeFriend.Core.Application.DTO.InterestCategoryDTOs
{
    public record InterestCategoryResponse(
        int CategoryId,
        string Name) : ResponseBase<int>
    {
        public override int Id => CategoryId;
    }
}
