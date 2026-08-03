using System.ComponentModel.DataAnnotations;

namespace BeeFriend.Core.Domain.Entities
{
    public class Country
    {
        public int CountryId { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = null!;

        public ICollection<City> Cities { get; } = new List<City>();

        public ICollection<UserProfile> UserProfiles { get; } = new List<UserProfile>();

    }
}
