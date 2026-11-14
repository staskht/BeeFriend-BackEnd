using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Application.DTO.ConversationUserDTOs
{
    public class ConversationUserRequest{
        public Guid ConversationId { get; set; }

        [Required]
        [MinLength(2)]
        public IEnumerable<Guid> Members { get; set; } = [];
    }
}
