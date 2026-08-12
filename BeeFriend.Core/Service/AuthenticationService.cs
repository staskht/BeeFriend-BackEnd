using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.IdentityEntities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Core.Domain.UnitOfWorkContract;
using BeeFriend.Core.DTO;
using BeeFriend.Core.Results;
using BeeFriend.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BeeFriend.Core.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationService(
            IJwtService jwtService, 
            UserManager<ApplicationUser> userManager,
            IUnitOfWork unitOfWork)
        {
            _jwtService = jwtService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<AuthenticationResponse>> RegisterAsync(RegisterRequest registerRequest)
        {
            ArgumentNullException.ThrowIfNull(registerRequest);

            var user = new ApplicationUser
            {
                Email = registerRequest.Email,
                UserName = registerRequest.Email
            };

            IdentityResult result =
                   await _userManager.CreateAsync(user, registerRequest.Password);

            if (!result.Succeeded)
            {
                return Errors.Validation(
                    "RegistrationValidation",
                    string.Join(
                    " | ",
                    result.Errors.Select(e => e.Description)));

            }
            await _unitOfWork.UserProfiles.CreateAsync(new UserProfile
            {
                UserId = user.Id,
                BirthDate = registerRequest.BirthDate
            });

            await _unitOfWork.CommitAsync();

            return await GenerateTokens(user);
        }

        public async Task<Result<AuthenticationResponse>> LoginAsync(LoginRequest loginRequest)
        {
            ArgumentNullException.ThrowIfNull(loginRequest);

            ApplicationUser? user =
                await _userManager.FindByEmailAsync(loginRequest.Email);

            if (user == null)
                return Errors.InvalidCredentials;

            bool valid =
                await _userManager.CheckPasswordAsync(user, loginRequest.Password);

            if (!valid)
                return Errors.InvalidCredentials;

            return await GenerateTokens(user);
        }

        public async Task<Result<AuthenticationResponse>> GenerateNewTokensAsync(TokenModel tokenModel)
        {
            ArgumentNullException.ThrowIfNull(tokenModel);

            ClaimsPrincipal? principal = 
                _jwtService.GetPrincipalFromJwtToken(tokenModel.AccessToken);

            if (principal == null)
                return Errors.InvalidAccessToken;

            string? userId = 
                principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(userId))
                return Errors.InvalidAccessToken;

            ApplicationUser? user = 
                await _userManager.FindByIdAsync(userId);

            if (user == null || 
                user.RefreshToken != tokenModel.RefreshToken || 
                user.RefreshTokenExpiryDate <= DateTime.UtcNow)
            {
                return Errors.InvalidRefreshToken;
            }

            return await GenerateTokens(user);
        }

        private async Task<AuthenticationResponse> GenerateTokens(ApplicationUser user)
        {
            var authenticationResponse = _jwtService.GenerateTokens(user);

            user.RefreshToken = authenticationResponse.RefreshToken;
            user.RefreshTokenExpiryDate = authenticationResponse.RefreshTokenExpiresAt;
            
            await _userManager.UpdateAsync(user);
            await _unitOfWork.CommitAsync();

            return authenticationResponse;
        }
    }
}
