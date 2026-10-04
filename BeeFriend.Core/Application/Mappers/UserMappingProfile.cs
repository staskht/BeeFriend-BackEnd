using AutoMapper;
using BeeFriend.Core.Application.DTO.UserProfileDTOs;
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
                opt => opt.MapFrom(src => src.Interests))

                .ForMember(dest => dest.PersonalityTraits,
                opt => opt.MapFrom(src => src.PersonalityTraits))

                .ForMember(dest => dest.FriendshipPreferences,
                opt => opt.MapFrom(src => src.FriendshipPreferences));


            CreateMap<UserProfilePatchRequest, UserProfile>();

            CreateMap<UserProfile, UserProfilePatchRequest>()

                .ForMember(dest => dest.InterestIds,
                opt => opt.MapFrom(src => src.Interests.Select(i => i.Id)))

                .ForMember(dest => dest.FriendshipPreferencesIds,
                opt => opt.MapFrom(src => src.FriendshipPreferences.Select(f => f.Id)))

                .ForMember(dest => dest.PersonalityTraitsIds,
                opt => opt.MapFrom(src => src.PersonalityTraits.Select(p => p.Id)));


        }
    }
}
