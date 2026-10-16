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

        public void Delete(Message message)
        {
            _context.Messages.Remove(message);
        }

        public async Task<IEnumerable<Message>> GetByConversationIdAsync(
            Guid convrsationId, 
            CancellationToken cancellationToken)
        {
            return await _context.Messages
                .Where(m => m.ConversationId == convrsationId)
                .ToListAsync();
        }

        public void Update(Message entity)
        {
            _context.Messages.Update(entity);
        }
    }
}
