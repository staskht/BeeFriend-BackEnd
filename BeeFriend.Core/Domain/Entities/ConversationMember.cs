using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.Entities
{
    public class ConversationMember
    {
        public Guid ConversationId { get; set; }
        public Guid UserId { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        public Conversation Conversation { get; set; } = null!;
        public UserProfile User { get; set; } = null!;
    }
}
