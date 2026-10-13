using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        public Guid SenderId { get; set; }

        [StringLength(3000)]
        public string Content { get; set; } = string.Empty;
        public DateTime SentAt { get; } = DateTime.UtcNow;

        public Conversation Conversation { get; set; } = null!;
        public UserProfile Sender { get; set; } = null!;
    }
}
