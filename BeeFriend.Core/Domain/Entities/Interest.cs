using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Domain.Entities
{
    public class Interest
    {
        public int InterestId { get; set; }
        public int CategoryId { get; set; }
        public InterestCategory Category { get; set; } = null!;

        [StringLength(30)]
        public string Name { get; set; } = null!;

        public ICollection<UserProfile> Users { get;  } = new List<UserProfile>();

    }
}
