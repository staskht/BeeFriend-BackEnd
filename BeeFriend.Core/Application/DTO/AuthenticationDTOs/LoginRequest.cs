using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Application.DTO.AuthenticationDTOs
{
    public class LoginRequest
    {
        [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
        public required string Email { get; init; }

        public required string Password { get; init; }
    }
}
