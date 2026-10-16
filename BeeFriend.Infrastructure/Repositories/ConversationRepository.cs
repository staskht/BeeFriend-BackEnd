using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Infrastructure.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly ApplicationDbContext _context;

        public ConversationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Conversation entity, CancellationToken cancellationToken)
        {
            await _context.Conversations.AddAsync(entity, cancellationToken);
        }

        public void Delete(Conversation conversation)
        {
            _context.Conversations.Remove(conversation);
        }

        public async Task<Conversation?> GetByMmembersIds(
            IEnumerable<UserProfile> members,
            CancellationToken cancellationToken)
        {
            return await _context.Conversations
                .Where(c => members.All(m => 
                c.Members.Any(cm => cm.Id == m.Id)))
                .FirstOrDefaultAsync(cancellationToken);
        }

        public void Update(Conversation entity)
        {
            _context.Conversations.Update(entity);
        }
    }
}
