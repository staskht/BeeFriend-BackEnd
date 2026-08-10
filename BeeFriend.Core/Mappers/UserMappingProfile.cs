using AutoMapper;
using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.DTO;
using BeeFriend.Core.Extensions;

namespace BeeFriend.Core.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserProfile, UserProfileResponse>()
                .ForMember(dest => dest.CityName,
                opt => opt.MapFrom(src => src.City != null ? src.City.Name : null))

                .ForMember(dest => dest.CountryName,
                opt => opt.MapFrom(src => src.Country != null ? src.Country.Name : null))

                .ForMember(dest => dest.Age, 
                opt => opt.MapFrom(src => src.BirthDate.CalculateAge()));
        }
    }
}
