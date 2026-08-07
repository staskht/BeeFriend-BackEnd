using BeeFriend.Core.Domain.IdentityEntities;
using BeeFriend.Core.DTO;
using BeeFriend.Core.ServiceContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BeeFriend.Core.Service
{
    public class JwtService : IJwtService
    {

        private readonly SymmetricSecurityKey _symmetricSecurityKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _accessTokenExpiryMinutes;
        private readonly int _refreshTokenExpiryDays;

        public JwtService(IConfiguration configuration)
        {

            _symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key is missing.")));

            _issuer = configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("Jwt:Issuer is missing."); 

            _audience = configuration["Jwt:Audience"] ?? throw new InvalidOperationException("Jwt:Audience is missing.");

            _accessTokenExpiryMinutes = int.Parse(configuration["Jwt:ExpiryMinutes"]!);

            _refreshTokenExpiryDays = int.Parse(configuration["RefreshToken:ExpiryDays"]!);
        }
        public AuthenticationResponse GenerateTokens(ApplicationUser user)
        {
            ArgumentNullException.ThrowIfNull(user);

            var expirationTime = DateTime.UtcNow.AddMinutes(_accessTokenExpiryMinutes);

            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                new Claim(
                    JwtRegisteredClaimNames.Iat,
                    EpochTime.GetIntDate(DateTime.UtcNow).ToString(),
                    ClaimValueTypes.Integer64),

                new Claim(JwtRegisteredClaimNames.Email, user.Email!),

            };

            var credentials = new SigningCredentials(
                _symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var tokenGenerator = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                expires: expirationTime,
                signingCredentials: credentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            string token = tokenHandler.WriteToken(tokenGenerator);

            return new AuthenticationResponse()
            {
                AccessToken = token,
                ExpiresAt = expirationTime,
                RefreshToken = GenerateRefreshToken(),
                RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays)
            };
        }

        public ClaimsPrincipal? GetPrincipalFromJwtToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidAudience = _audience,
                ValidateIssuer = true,
                ValidIssuer = _issuer,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _symmetricSecurityKey,

                ValidateLifetime = false,

                ClockSkew = TimeSpan.Zero 

            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal = jwtSecurityTokenHandler.ValidateToken(
                token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken 
                || !jwtSecurityToken.Header.Alg.Equals(
                    SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            return principal;
        }

        private string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
