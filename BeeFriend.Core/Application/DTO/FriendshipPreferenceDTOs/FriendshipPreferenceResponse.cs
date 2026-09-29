using BeeFriend.Core.Application.DTO.Interfaces;
using System.Text.Json.Serialization;

namespace BeeFriend.Core.Application.DTO.FriendshipPreferenceDTOs
{
    public record FriendshipPreferenceResponse(
        int Id,
        string Name) : IResponse<int>;
}