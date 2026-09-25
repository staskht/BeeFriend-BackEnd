namespace BeeFriend.Core.Application.DTO.PersonalityDTOs
{
    public record PersonalityResponse(
        int PerosnalityId,
        string Name) : ResponseBase<int>
    {
        public override int Id => PerosnalityId;
    }

}