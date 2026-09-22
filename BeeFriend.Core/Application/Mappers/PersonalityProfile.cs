using AutoMapper;
using BeeFriend.Core.Application.DTO.PersonalityDTOs;
using BeeFriend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.Mappers
{
    public class PersonalityProfile : Profile
    {
        public PersonalityProfile() 
        {
            CreateMap<Personality,PersonalityResponse>();
            CreateMap<PersonalityRequest, Personality>();
        }
    }
}
