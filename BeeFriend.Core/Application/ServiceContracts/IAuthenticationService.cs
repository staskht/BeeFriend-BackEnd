using System;
using System.Collections.Generic;
using System.Text;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.Results;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface IAuthenticationService
    {
        Task<Result<AuthenticationResponse>> RegisterAsync(RegisterRequest registerRequest);
        Task<Result<AuthenticationResponse>> LoginAsync(LoginRequest loginRequest);
        Task<Result<AuthenticationResponse>> GenerateNewTokensAsync(TokenModel tokenModel);

    }
}
