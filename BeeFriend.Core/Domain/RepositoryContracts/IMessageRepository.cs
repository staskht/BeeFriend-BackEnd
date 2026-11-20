using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts;
using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts.Getters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.RepositoryContracts
{
    public interface IMessageRepository :
        ICreatorRepository<Message>,
        IUpdaterRepository<Message>,
        IGetByIdRepository<Message, Guid>
    {
        Task<IEnumerable<Message>> GetMessagesByConversationIdAsync(
            Guid conversationId,
            int page,
            int limit,
            CancellationToken cancellationToken);

        Task<bool> ExecuteDeleteMessageAsync(
            Guid messageId,
            Guid userId,
            CancellationToken cancellationToken);
    }
        
}
