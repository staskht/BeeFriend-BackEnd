using AutoMapper;
using BeeFriend.Core.Application.DTO.MessageDTOs;
using BeeFriend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.Mappers
{
    internal class MessageProfile : Profile
    {
        public MessageProfile() 
        {
            CreateMap<Message, MessageResponse>();
        }
    }
}
