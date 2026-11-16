using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.DTO.MessageDTOs
{
    public record MessageResponse(string Content, DateTime SentAt, string SenderName);
}
