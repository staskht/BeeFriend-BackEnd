using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.DTO
{
    public record AuthenticationResponse
    {
        public required string Token { get; init; }

        public required DateTime ExpiresAt { get; init; }
    }
}
