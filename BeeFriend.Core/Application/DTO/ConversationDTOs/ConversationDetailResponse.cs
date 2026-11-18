using BeeFriend.Core.Application.DTO.ConversationUserDTOs;
using BeeFriend.Core.Application.DTO.MessageDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.DTO.ConversationDTOs
{
    public record ConversationDetailResponse(Guid Id, IEnumerable<ConversationUserMessageResponse> Members, DateTime CreatedAt);
}
