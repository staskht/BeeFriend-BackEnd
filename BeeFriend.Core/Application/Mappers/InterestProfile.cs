using AutoMapper;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Domain.Entities;

namespace BeeFriend.Core.Application.Mappers
{
    public class InterestProfile : Profile
    {
        public InterestProfile() 
        {
            CreateMap<InterestCategory, InterestsWithCategoriesResponse>()
                .ForMember(dest => dest.Interests,
                opt => opt.MapFrom(src => src.Interests));
        }
    }
}
