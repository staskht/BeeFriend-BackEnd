namespace BeeFriend.Core.Application.DTO.FriendshipPreferenceDTOs
{
    public record FriendshipPreferenceResponse(
        int PreferenceId,
        string Name) : ResponseBase<int>
    {
        public override int Id => PreferenceId;
    }
}