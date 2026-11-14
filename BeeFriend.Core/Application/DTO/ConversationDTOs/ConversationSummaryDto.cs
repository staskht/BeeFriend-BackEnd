using BeeFriend.Core.Application.DTO.MessageDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.DTO.ConversationDTOs
{
    public record ConversationSummaryDto(
        Guid ConversationId,
        MessagePreviewDto? LastMessage);
}
