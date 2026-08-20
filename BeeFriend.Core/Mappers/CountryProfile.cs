using AutoMapper;
using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Mappers
{
    public class CountryProfile : Profile
    {
        public CountryProfile() 
        {
            CreateMap<Country, CountryResponse>();
        }
    }
}
