using BeeFriend.Core.Application.DTO.ConversationDTOs;
using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts.Getters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface IConversationRepository :
        ICreatorRepository<Conversation>,
        IGetByIdRepository<Conversation, Guid>,
        IDeleterRepository<Conversation>
    {
        Task<IEnumerable<ConversationSummaryDto>> GetUsersConversationsSummariesAsync(
            Guid userId, 
            CancellationToken cancellationToken);
        Task<bool> IsUserMemberOfConversationAsync(
            Guid userId,
            Guid conversationId,
            CancellationToken cancellationToken);

        Task<bool> AreUsersMembersOfConversationAsync(
            IEnumerable<Guid> usersIds,
            Guid conversationId,
            CancellationToken cancellationToken);

    }
}
