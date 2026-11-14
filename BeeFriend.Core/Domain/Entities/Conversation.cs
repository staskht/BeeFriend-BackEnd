using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.Entities
{
    public class Conversation
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public ICollection<ConversationUser> Members { get; } = new List<ConversationUser>();
        public ICollection<Message> Messages { get; } = new List<Message>();

        private Conversation()
        {

        }

        private Conversation(IEnumerable<ConversationUser> members)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            
            foreach(var member in members)
            {
                Members.Add(member);
            }
        }

        internal static Conversation Create(IEnumerable<ConversationUser> members)
        {
            ArgumentNullException.ThrowIfNull(members);

            var membersList = members.ToList();

            if (membersList.Count < 2)
                throw new ArgumentException(
                    "A conversation must have at least two members.",
                    nameof(members));

            return new Conversation(membersList);
        }

        internal static Conversation CreateStub(Guid id)
        {
            return new Conversation
            {
                Id = id,
            };
        }
    }
}
