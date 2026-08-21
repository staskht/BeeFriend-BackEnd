using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface ITokenAuthentication
    {
        AuthenticationResponse GenerateTokens(ApplicationUser user);
        ClaimsPrincipal? GetPrincipalFromJwtToken(string? token);
    }
}
