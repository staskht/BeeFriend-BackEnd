using BeeFriend.Core.Application.DTO.MessageDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.DTO.ConversationDTOs
{
    public record ConversationResponse(IEnumerable<string> memberNames, IEnumerable<MessageResponse> Messages, DateTime CreatedAt);
}
