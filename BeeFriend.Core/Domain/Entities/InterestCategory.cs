using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.Entities
{
    public class InterestCategory
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Interest> Interests { get; } = new List<Interest>();
    }
}
