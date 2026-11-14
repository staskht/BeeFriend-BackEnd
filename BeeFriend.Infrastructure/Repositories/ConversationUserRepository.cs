using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Infrastructure.Repositories
{
    public class ConversationUserRepository : IConversationUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ConversationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ConversationUser conversationUser)
        {
            _context.ConversationUser.Add(conversationUser);
        }

        public void Delete(ConversationUser conversationUser) 
        {
            _context.ConversationUser.Remove(conversationUser);
        }

        public async Task<int> ConversationMembersCount(Guid conversationId)
        {
            return await _context.ConversationUser.CountAsync(
                cu => cu.ConversationId == conversationId);
        }
    }
}
