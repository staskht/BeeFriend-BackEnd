using BeeFriend.Core.Domain.IdentityEntities;
using BeeFriend.Core.Enums;
using System.ComponentModel.DataAnnotations;


namespace BeeFriend.Core.Domain.Entities
{
    public class UserProfile
    {
        
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public int? CityId { get; set; }

        public City? City { get; set; }

        public int? CountryId { get; set; }

        public Country? Country { get; set; }

        [StringLength(50)]
        public string? FirstName {get; set;}

        [StringLength(200)]
        public string? Bio {get; set; }

        public DateTime BirthDate { get; set; }

        public GenderOptions? Gender {get; set;}

        public PronounsOptions? Pronouns {get; set;}

        [StringLength(200)]
        public string? Interests { get; set;  }
        
    }
}
