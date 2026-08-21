using AutoMapper;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.Mappers
{
    public class CountryProfile : Profile
    {
        public CountryProfile() 
        {
            CreateMap<Country, CountryResponse>();
        }
    }
}
