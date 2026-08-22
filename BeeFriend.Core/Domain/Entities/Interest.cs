using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.Entities
{
    public class Interest
    {
        public int InterestId { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<UserProfile> Users = new List<UserProfile>();

    }
}
