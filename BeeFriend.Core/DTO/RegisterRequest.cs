using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.DTO
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
        public required string Email { get; init; }


        [Required(ErrorMessage = "Password can't be blank")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public required string Password { get; init; }


        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public required string ConfirmPassword { get; init; }
    }
}
