namespace BeeFriend.Core.Application.DTO
{
    public record CityResponse(
        int Id,
        string Name,
        double? Latitude = null,
        double? Longitude = null
        );
}
