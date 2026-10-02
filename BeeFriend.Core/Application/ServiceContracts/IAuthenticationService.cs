using System;
using System.Collections.Generic;
using System.Text;
using BeeFriend.Core.Application.DTO.AuthenticationDTOs;
using BeeFriend.Core.Application.Results;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface IAuthenticationService
    {
        Task<Result<AuthenticationResponse>> RegisterAsync(
            RegisterRequest registerRequest, 
            CancellationToken cancellationToken);
        Task<Result<AuthenticationResponse>> LoginAsync(
            LoginRequest loginRequest, 
            CancellationToken cancellationToken);
        Task<Result<AuthenticationResponse>> GenerateNewTokensAsync(
            TokenModel tokenModel, 
            CancellationToken cancellationToken);

    }
}
