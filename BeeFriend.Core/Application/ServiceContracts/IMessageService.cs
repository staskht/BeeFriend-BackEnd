using BeeFriend.Core.Application.DTO.MessageDTOs;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface IMessageService
    {
        Task<Result<IEnumerable<MessageResponse>>> GetMessagesByConversationIdAsync(
            Guid conversationId,
            Guid currentUserId,
            int page,
            int limit,
            CancellationToken cancellationToken);

        Task<Result> DeleteMessageAsync(
            Guid currentUserId,
            Guid messageId,
            CancellationToken cancellationToken);

        Task<Result<MessageResponse>> SendAsync(
            Guid currentUserId,
            Guid conversationId,
            MessageCreateRequest messageCreateRequest,
            CancellationToken cancellationToken);
    }
}
