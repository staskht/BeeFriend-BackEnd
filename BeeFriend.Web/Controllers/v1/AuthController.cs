using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.ServiceContracts;
using BeeFriend.Core.Application.Results;

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

            return ReturnResponse(
                result, 
                value => StatusCode(StatusCodes.Status201Created, value));
        }


        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> PostLogin(LoginRequest loginRequest) 
        {
            Result<AuthenticationResponse> result = 
                await _authenticationService.LoginAsync(loginRequest);

            return ReturnResponse(result, value => Ok(value));
        }

        [HttpPost("generate-tokens")]
        public async Task<ActionResult<AuthenticationResponse>> GenerateTokens(TokenModel tokenModel)
        {
            Result<AuthenticationResponse> result =
                await _authenticationService.GenerateNewTokensAsync(tokenModel);

             return ReturnResponse(result, value => Ok(value));
        }
    }
}
