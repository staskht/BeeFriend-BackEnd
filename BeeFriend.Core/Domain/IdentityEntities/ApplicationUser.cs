using BeeFriend.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Domain.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public UserProfile? UserProfile { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryDate { get; set; }
    }
}
