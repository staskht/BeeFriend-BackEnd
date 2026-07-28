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

            ApplicationUser? user = await _userManager.FindByIdAsync(userId!);

            if (user == null || user.RefreshToken != tokenModel.RefreshToken || user.RefreshTokenExpiryDate <= DateTime.UtcNow)
            {
                return Unauthorized("Invalid refresh token");
            }

            AuthenticationResponse authenticationResponse = _jwtService.GenerateTokens(user);

            user.RefreshToken = authenticationResponse.RefreshToken;
            user.RefreshTokenExpiryDate = authenticationResponse.RefreshTokenExpiresAt;

            IdentityResult result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return StatusCode(500);
            }

            return Ok(authenticationResponse);
        }

    }
}
