using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.DTO
{
    public record TokenModel
    {
        public required string AccessToken { get; init; }

        public required string RefreshToken { get; init; }
    }
}
