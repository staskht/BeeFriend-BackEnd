using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; private set; }
        public Guid ConversationId { get; private set; }
        public Guid SenderId { get; private set; }

        [StringLength(3000)]
        public string Content { get; private set; } = string.Empty;
        public DateTime SentAt { get; init; }

        public Conversation Conversation { get; private set; } = null!;
        public UserProfile Sender { get; private set; } = null!;

        private Message(Guid conversationId, Guid senderId, string content)
        {
            ConversationId = conversationId;
            SenderId = senderId;
            Content = content;
            SentAt =  DateTime.UtcNow;
        }

        private Message() { }

        public static Message Create(Guid conversationId, Guid senderId, string content)
        {
            var message = new Message(conversationId, senderId, content);

            return message;
        }

    }
}
