using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.DTO;
using BeeFriend.Core.Extensions;

namespace BeeFriend.Core.Mappers
{
    internal static class UserMapper
    {
        public static UserProfileResponse ToDto(this UserProfile user)
        {
            return new UserProfileResponse()
            {
                UserId = user.UserId,
                CityName = user.City?.Name,
                CountryName = user.Country?.Name,
                FirstName = user.FirstName,
                Bio = user.Bio,
                Age = user.BirthDate.CalculateAge(),
                Gender = user.Gender,
                Pronouns = user.Pronouns,
                Interests = user.Interests,
            };
        }
    }
}
