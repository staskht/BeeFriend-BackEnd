using BeeFriend.Core.Application.DTO.ConversationDTOs;
using BeeFriend.Core.Application.DTO.ConversationUserDTOs;
using BeeFriend.Core.Application.DTO.MessageDTOs;
using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace BeeFriend.Infrastructure.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly ApplicationDbContext _context;

        public ConversationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(
            Conversation entity, 
            CancellationToken cancellationToken)
        {
            await _context.Conversations.AddAsync(entity, cancellationToken);
        }

        public async Task<bool> IsUserMemberOfConversationAsync(
            Guid userId,
            Guid conversationId,
            CancellationToken cancellationToken)
        {
            return await _context.Conversations
                .AnyAsync(
                    c => c.Id == conversationId &&
                    c.Members.Any(u => u.UserId == userId),
                    cancellationToken);
        }

        public async Task<bool> AreUsersMembersOfConversationAsync(
            IEnumerable<Guid> usersIds,
            Guid conversationId,
            CancellationToken cancellationToken)
        {
            var ids = usersIds.ToArray();

            return await _context.Conversations
                .AnyAsync(
                    c => c.Id == conversationId &&
                    c.Members.Any(u => ids.Contains(u.UserId)),
                    cancellationToken);
        }

        public async Task<ConversationDetailResponse?> GetByIdAsync(Guid conversationId, CancellationToken cancellationToken)
        {
            return await _context.Conversations
                .Where(c => c.Id == conversationId)
                .Select(c => new ConversationDetailResponse(
                    c.Id,
                    c.Members.Select(m => new ConversationUserMessageResponse(
                        m.UserId,
                        m.UserProfile.FirstName
                        )).ToList(),
                    c.CreatedAt
                    ))
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<ConversationSummaryDto>> GetUsersConversationsSummariesAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _context.Conversations
                .Where(c => c.Members.Any(u => u.UserId ==  userId))
                .Select(c => new ConversationSummaryDto(
                    c.Id,
                    c.Messages
                    .OrderByDescending(m => m.SentAt)
                    .Select(m => new MessagePreviewDto(
                        m.Content,
                        m.SentAt,
                        m.Sender.FirstName))
                    .FirstOrDefault()
                    ))
                .ToListAsync(cancellationToken);
        }

        public void Delete(Conversation entity)
        {
            _context.Conversations.Remove(entity);
        }
    }
}
