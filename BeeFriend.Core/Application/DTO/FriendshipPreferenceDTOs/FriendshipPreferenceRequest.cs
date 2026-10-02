using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeeFriend.Core.Application.DTO.FriendshipPreferenceDTOs
{
    public record FriendshipPreferenceRequest(
        string Name);
}
