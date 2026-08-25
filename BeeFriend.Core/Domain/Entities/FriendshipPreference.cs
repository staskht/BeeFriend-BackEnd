using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Domain.Entities
{
    public class FriendshipPreference
    {
        public int PreferenceId { get; set; }

        [StringLength(30)]
        public string Name { get; set; } = null!;

        public ICollection<UserProfile> Users { get; } = new List<UserProfile>();
    }
}
