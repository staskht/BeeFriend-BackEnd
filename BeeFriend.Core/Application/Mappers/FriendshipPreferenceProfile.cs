using AutoMapper;
using BeeFriend.Core.Application.DTO.FriendshipPreferenceDTOs;
using BeeFriend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.Mappers
{
    public class FriendshipPreferenceProfile : Profile
    {
        public FriendshipPreferenceProfile()
        {
            CreateMap<FriendshipPreference, FriendshipPreferenceResponse>();
            CreateMap<FriendshipPreferenceRequest, FriendshipPreference>();
        }
    }
}
