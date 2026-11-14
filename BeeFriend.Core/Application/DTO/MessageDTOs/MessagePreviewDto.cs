using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.DTO.MessageDTOs
{
    public record MessagePreviewDto(
        string lastMessage, 
        DateTime sentAt, 
        string user);
}
