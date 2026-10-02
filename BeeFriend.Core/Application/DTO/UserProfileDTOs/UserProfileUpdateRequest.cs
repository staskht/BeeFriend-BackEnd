using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace BeeFriend.Core.Application.DTO.UserProfileDTOs
{
    public record UserProfileUpdateRequest(
    int? CityId,
    int? CountryId,

    [param: StringLength(50, ErrorMessage = "{0} cannot be more than {1} characters.")]
    string? FirstName,

    [param: StringLength(200, ErrorMessage = "{0} cannot be more than {1} characters.")]
    string? Bio,

    GenderOptions? Gender,
    PronounsOptions? Pronouns,
    IEnumerable<int>? InterestIds,
    IEnumerable<int>? PersonalityTraitsIds,
    IEnumerable<int>? FriendshipPreferencesIds);
}
