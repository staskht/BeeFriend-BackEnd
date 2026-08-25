using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Domain.Entities
{
    public class Personality
    {
        public int PerosnalityId { get; set; }

        [StringLength(30)]
        public string Name { get; set; } = null!;

        public ICollection<UserProfile> Users { get; } = new List<UserProfile>();

    }
}
