using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Application.DTO.AuthenticationDTOs
{
    public class RegisterRequest
    {
        [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
        public required string Email { get; init; }


        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public required string Password { get; init; }


        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public required string ConfirmPassword { get; init; }


        [Required(ErrorMessage = "Birth Date is required.")]
        public required DateTime BirthDate { get; init; }
    }
}
