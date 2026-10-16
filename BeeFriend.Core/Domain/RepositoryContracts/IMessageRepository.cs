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
        IDeleterRepository<Message>,
        IUpdaterRepository<Message>
    {
        Task<IEnumerable<Message>> GetByConversationIdAsync(
            Guid convrsationId,
            CancellationToken cancellationToken);
    }
        
}
