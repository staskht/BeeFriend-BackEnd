
using AutoMapper;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Domain.Entities;

namespace BeeFriend.Core.Application.Mappers
{
    public class CityProfile : Profile
    {
        public CityProfile() 
        {
            CreateMap<City, CityResponse>();
        }
    }
}
