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

       
    }
}
