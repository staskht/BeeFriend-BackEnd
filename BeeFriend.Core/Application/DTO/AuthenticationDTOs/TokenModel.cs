using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.DTO.AuthenticationDTOs
{
    public record TokenModel(
        string AccessToken, 
        string RefreshToken);
}
