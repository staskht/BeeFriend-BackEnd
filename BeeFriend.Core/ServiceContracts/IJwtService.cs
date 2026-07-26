using BeeFriend.Core.Domain.IdentityEntities;
using BeeFriend.Core.DTO;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BeeFriend.Core.ServiceContracts
{
    public interface IJwtService
    {
        AuthenticationResponse GenerateTokens(ApplicationUser user);
        ClaimsPrincipal? GetPrincipalFromJwtToken(string? token);
    }
}
