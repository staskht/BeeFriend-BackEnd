using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Application.DTO.ConversationDTOs
{
    public class ConversationAddRequest
    {

        [Required]
        [MinLength(1)]
        public HashSet<Guid> Members { get; init; } = [];
    }
}
