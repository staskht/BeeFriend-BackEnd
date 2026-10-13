using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.Entities
{
    public class Conversation
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<UserProfile> Members { get; } = new List<UserProfile>();
        public ICollection<Message> Messages { get; } = new List<Message>();

    }
}
