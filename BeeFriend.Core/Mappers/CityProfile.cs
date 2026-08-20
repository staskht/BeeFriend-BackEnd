
using AutoMapper;
using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.DTO;

namespace BeeFriend.Core.Mappers
{
    public class CityProfile : Profile
    {
        public CityProfile() 
        {
            CreateMap<City, CityResponse>();
        }
    }
}
