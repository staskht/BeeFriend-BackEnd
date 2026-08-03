using BeeFriend.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.DTO
{
    public class UserProfileUpdateRequest
    {
        [Required(ErrorMessage = "User Id cannot be blank")]
        public Guid UserId { get; set; }

        public int? CityId { get; set; }

        public int? CountryId { get; set; }

        [StringLength(50, ErrorMessage = "{0} cannot be more than {1} characters.")]
        public string? FirstName { get; set; }

        [StringLength(200, ErrorMessage = "{0} cannot be more than {1} characters.")]
        public string? Bio { get; set; }

        public GenderOptions? Gender { get; set; }

        public PronounsOptions? Pronouns { get; set; }

        [StringLength(200, ErrorMessage = "{0} cannot be more than {1} characters.")]
        public string? Interests { get; set; }
    }
}
