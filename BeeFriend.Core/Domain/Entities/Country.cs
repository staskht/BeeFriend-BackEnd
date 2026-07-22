using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Domain.Entities
{
    public class Country
    {
        public int CountryId { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = null!;
        public ICollection<City> Cities { get; } = new List<City>();
    }
}
