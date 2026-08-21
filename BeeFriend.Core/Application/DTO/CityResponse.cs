namespace BeeFriend.Core.Application.DTO
{
    public record CityResponse(
        int CityId,
        string Name,
        double? Latitude = null,
        double? Longitude = null
        );
}
