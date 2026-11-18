using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.DTO.ConversationUserDTOs
{
    public record ConversationUserMessageResponse(Guid UserId, string UserFirstName);
}
