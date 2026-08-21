using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.DTO
{
    public record AuthenticationResponse
    {
        public required string AccessToken { get; init; }

        public required DateTime ExpiresAt { get; init; }

        public required string RefreshToken { get; init; }

        public required DateTime RefreshTokenExpiresAt { get; init; }

    }
}
