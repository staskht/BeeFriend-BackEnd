using AutoMapper;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.DTO.InterestCategoryDTOs;
using BeeFriend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.Mappers
{
    public class InterestCategoryProfile : Profile
    {
        public InterestCategoryProfile() 
        {
            CreateMap<InterestCategory, InterestCategoryResponse>();
            CreateMap<InterestCategoryRequest, InterestCategory>();
            CreateMap<InterestCategory, InterestsWithCategoriesResponse>();
        }
    }
}
