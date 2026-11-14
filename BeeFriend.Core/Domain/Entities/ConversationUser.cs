using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.Entities
{
    public class ConversationUser
    {
        public Guid ConversationId { get; set; }
        public Guid UserId { get; set; }

        public Conversation Conversation { get; set; } = null!;
        public UserProfile UserProfile { get; set; } = null!;
    }
}
