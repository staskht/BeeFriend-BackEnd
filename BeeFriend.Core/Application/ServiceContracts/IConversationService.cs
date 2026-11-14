using BeeFriend.Core.Application.DTO.ConversationDTOs;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface IConversationService
    {
        Task<Result<Guid>> CreateAsync(
            Guid currentUser,
            ConversationCreateRequest conversationCreateRequest,
            CancellationToken cancellationToken);

        Task<Result<IEnumerable<ConversationSummaryDto>>> GetUsersConversationsSummariesAsync(
            Guid userId,
            CancellationToken cancellationToken);

        Task<Result> AddMembersAsync(
            Guid currentUserId,
            Guid conversationId,
            ConversationAddRequest conversationAddRequest,
            CancellationToken cancellationToken);

    }
}
