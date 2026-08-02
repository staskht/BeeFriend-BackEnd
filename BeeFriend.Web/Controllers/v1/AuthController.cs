using Asp.Versioning;
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
        private readonly IJwtService _jwtService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IJwtService jwtService, UserManager<ApplicationUser> userManager)
        {
            _jwtService = jwtService;
            _userManager = userManager;
        }

        /// <summary>
        /// Validates the user, saves it in the database and returns AuthenticationResponse
        /// </summary>
        /// <param name="registerRequest">represents the user's details as RegisterRequest</param>
        /// <returns>AuthenticationResponse</returns>
        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationResponse>> PostRegister(RegisterRequest registerRequest) 
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                return Problem(errorMessage);
            }

            var user = new ApplicationUser 
            { 
                Email = registerRequest.Email,
                UserName = registerRequest.Email
            };

            IdentityResult result = 
                await _userManager.CreateAsync(user, registerRequest.Password);

            if (result.Succeeded)
            {
                AuthenticationResponse authenticationResponse = _jwtService.GenerateTokens(user);

                user.RefreshToken = authenticationResponse.RefreshToken;
                user.RefreshTokenExpiryDate = authenticationResponse.RefreshTokenExpiresAt;

                await _userManager.UpdateAsync(user);

                return authenticationResponse;
            }
            else
            {
                string errorMessage = string.Join(" | ", result.Errors
                    .Select(e => e.Description)); 

                return Problem(errorMessage);
            }
        }


        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> PostLogin(LoginRequest loginRequest) 
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                return Problem(errorMessage);
            }

            ApplicationUser? user = 
                await _userManager.FindByEmailAsync(loginRequest.Email);

            if (user == null)
            {
                return Unauthorized("User does not exist");
            }

            bool valid = 
                await _userManager.CheckPasswordAsync(user, loginRequest.Password);

            if (!valid)
            {
                return Unauthorized("The password did not match.");
            }

            AuthenticationResponse authenticationResponse = _jwtService.GenerateTokens(user);

            user.RefreshToken = authenticationResponse.RefreshToken;
            user.RefreshTokenExpiryDate = authenticationResponse.RefreshTokenExpiresAt;

            await _userManager.UpdateAsync(user);

            return authenticationResponse;
        }

        [HttpPost("generate-tokens")]
        public async Task<IActionResult> GenerateTokens(TokenModel tokenModel)
        {
            if (tokenModel == null)
            {
                return BadRequest("Invalid client request");
            }

            ClaimsPrincipal? principal = _jwtService.GetPrincipalFromJwtToken(tokenModel.AccessToken);

            if (principal == null)
            {
                return Unauthorized("Invalid jwt access token");
            }

            string? userId = principal.FindFirstValue(JwtRegisteredClaimNames.Sub);

            ApplicationUser? user = 
                await _userManager.FindByIdAsync(userId!);

            if (user == null || user.RefreshToken != tokenModel.RefreshToken || user.RefreshTokenExpiryDate <= DateTime.UtcNow)
            {
                return Unauthorized("Invalid refresh token");
            }

            AuthenticationResponse authenticationResponse = _jwtService.GenerateTokens(user);

            user.RefreshToken = authenticationResponse.RefreshToken;
            user.RefreshTokenExpiryDate = authenticationResponse.RefreshTokenExpiresAt;

            IdentityResult result = 
                await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return StatusCode(500);
            }

            return Ok(authenticationResponse);
        }

    }
}
