
namespace BeeFriend.Core.DTO
{
    public record CityResponse(
        int CityId,
        string Name,
        double? Latitude = null,
        double? Longitude = null
        );
}
