using BeeFriend.Core.Results;
using BeeFriend.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.ServiceContracts
{
    public interface IAuthenticationService
    {
        Task<Result<AuthenticationResponse>> RegisterAsync(RegisterRequest registerRequest);

        Task<Result<AuthenticationResponse>> LoginAsync(LoginRequest loginRequest);

        Task<Result<AuthenticationResponse>> GenerateNewTokensAsync(TokenModel tokenModel);

    }
}
