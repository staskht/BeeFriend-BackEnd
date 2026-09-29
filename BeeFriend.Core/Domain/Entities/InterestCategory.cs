using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Domain.Entities
{
    public class InterestCategory
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; } = null!;

        public ICollection<Interest> Interests { get; } = new List<Interest>();
    }
}
