using BeeFriend.Core.Application.DTO.Interfaces;

namespace BeeFriend.Core.Application.DTO.PersonalityDTOs
{
    public record PersonalityResponse(
        int Id,
        string Name) : IResponse<int>;

}