using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.DTO
{
    public record LoginRequest
    {
        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
        public required string Email { get; init; }


        [Required(ErrorMessage = "Password can't be blank")]
        public required string Password { get; init; }
    }
}
