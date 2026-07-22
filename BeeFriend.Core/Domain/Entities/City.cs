using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BeeFriend.Core.Domain.Entities
{
    public class City
    {
        public int CityId { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!; 
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public ICollection<UserProfile> UserProfiles { get;} = new List<UserProfile>();
    }
}
