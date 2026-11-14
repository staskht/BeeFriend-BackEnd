using BeeFriend.Core.Application.DTO.FriendshipPreferenceDTOs;
using BeeFriend.Core.Application.DTO.InterestDTOs;
using BeeFriend.Core.Application.DTO.PersonalityDTOs;
using BeeFriend.Core.Domain.Enums;
using System.Text.Json.Serialization;

namespace BeeFriend.Core.Application.DTO.UserProfileDTOs
{
    public class UserProfileResponse
    {
        public Guid Id { get; set; }
        public string? CityName { get; set; }
        public string? CountryName { get; set; }
        public string FirstName { get; set; } = null!;
        public string? Bio { get; set; }
        public int Age { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public GenderOptions? Gender { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PronounsOptions? Pronouns { get; set; }

        public IEnumerable<InterestResponse> Interests { get; set; } = [];
        public IEnumerable<PersonalityResponse> PersonalityTraits { get; set; } = [];
        public IEnumerable<FriendshipPreferenceResponse> FriendshipPreferences { get; set; } = [];
    }
}
