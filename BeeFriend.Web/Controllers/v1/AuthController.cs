using Asp.Versioning;
using BeeFriend.Core.Results;
using BeeFriend.Core.Domain.IdentityEntities;
using BeeFriend.Core.DTO;
using BeeFriend.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BeeFriend.Web.Controllers.v1
{
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class AuthController : CustomControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Validates the user, saves it in the database and returns AuthenticationResponse
        /// </summary>
        /// <param name="registerRequest">represents the user's details as RegisterRequest</param>
        /// <returns>AuthenticationResponse</returns>
        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationResponse>> PostRegister(RegisterRequest registerRequest) 
        {   
            Result<AuthenticationResponse> result = 
                await _authenticationService.RegisterAsync(registerRequest);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }


        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> PostLogin(LoginRequest loginRequest) 
        {
            Result<AuthenticationResponse> result = 
                await _authenticationService.LoginAsync(loginRequest);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }

        [HttpPost("generate-tokens")]
        public async Task<ActionResult<AuthenticationResponse>> GenerateTokens(TokenModel tokenModel)
        {
            Result<AuthenticationResponse> result =
                await _authenticationService.GenerateNewTokensAsync(tokenModel);

            if (result.IsFailure)
                return HandleFailure(result);

            return Ok(result.Value);
        }

    }
}
