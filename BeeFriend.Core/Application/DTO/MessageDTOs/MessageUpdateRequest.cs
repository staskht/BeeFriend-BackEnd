using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Application.DTO.MessageDTOs
{
    public class MessageUpdateRequest
    {
        [Required]
        [StringLength(2000)]
        public string Content { get; set; } = string.Empty;
    }
}
