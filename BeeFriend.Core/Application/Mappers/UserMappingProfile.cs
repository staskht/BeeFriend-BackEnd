using AutoMapper;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Extensions;

namespace BeeFriend.Core.Application.Mappers
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
                opt => opt.MapFrom(src => src.BirthDate.CalculateAge()))

                .ForMember(dest => dest.Interests,
                opt => opt.MapFrom(src => src.Interests));
        }
    }
}
