using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Message entity, CancellationToken cancellationToken)
        {
            await _context.Messages.AddAsync(entity, cancellationToken);
        }

        public async Task<bool> ExecuteDeleteMessageAsync(
            Guid messageId,
            Guid userId,
            CancellationToken cancellationToken)
        {
            var affectedRows = await _context.Messages
                .Where(m => m.Id == messageId &&
                            m.SenderId == userId)
                .ExecuteDeleteAsync(cancellationToken);

            return affectedRows > 0;
        }

        public async Task<Message?> GetByIdAsync(Guid messageId, CancellationToken cancellationToken)
        {
            return await _context.Messages.FirstOrDefaultAsync(x => x.Id == messageId, 
                cancellationToken);
        }

        public async Task<IEnumerable<Message>> GetMessagesByConversationIdAsync(
            Guid conversationId,
            int page,
            int limit,
            CancellationToken cancellationToken)
        {
            return await _context.Messages
                .AsNoTracking()
                .Where(m => m.ConversationId == conversationId)
                .OrderByDescending(m => m.SentAt)
                .ThenByDescending(m => m.Id)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync(cancellationToken);
        }

        public void Update(Message entity)
        {
            _context.Messages.Update(entity);
        }
    }
}
