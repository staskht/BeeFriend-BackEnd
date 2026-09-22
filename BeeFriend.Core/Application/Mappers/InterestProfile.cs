using AutoMapper;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.DTO.InterestDTOs;
using BeeFriend.Core.Domain.Entities;

namespace BeeFriend.Core.Application.Mappers
{
    public class InterestProfile : Profile
    {
        public InterestProfile() 
        {

            CreateMap<Interest, InterestResponse>();
            CreateMap<InterestRequest, Interest>();
        }
    }
}
