using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.DTO.InterestCategoryDTOs;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.ServiceContracts
{
    public interface IInterestCategoriesService 
        : ICrudService<InterestCategoryRequest, InterestCategoryResponse, int>
    {
        Task<Result<IEnumerable<InterestsWithCategoriesResponse>>> GetAllCategoriesWithInterestsAsync();
    }
}
