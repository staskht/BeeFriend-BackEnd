
using BeeFriend.Core.Enums;


namespace BeeFriend.Core.DTO
{
    public class UserProfileResponse
    {
        public Guid UserId { get; set; }

        public string? CityName { get; set; }

        public string? CountryName { get; set; }

        public string? FirstName { get; set; }

        public string? Bio { get; set; }

        public int Age { get; set; }

        public GenderOptions? Gender { get; set; }

        public PronounsOptions? Pronouns { get; set; }

        public string? Interests { get; set; }
    }
}
