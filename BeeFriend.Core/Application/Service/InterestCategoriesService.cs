using AutoMapper;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.DTO.InterestCategoryDTOs;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts;
using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Core.Domain.UnitOfWorkContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Core.Application.Service
{
    public class InterestCategoriesService 
        : CrudService<
            InterestCategory, 
            InterestCategoryRequest, 
            InterestCategoryResponse, 
            int, 
            IInterestCategoriesRepository>,
        IInterestCategoriesService
    {
        public InterestCategoriesService(
            IInterestCategoriesRepository repository, 
            IMapper mapper, 
            IUnitOfWork unitOfWork) 

            : base(repository, mapper, unitOfWork)
        {

        }

        public async Task<Result<IEnumerable<InterestsWithCategoriesResponse>>> GetAllCategoriesWithInterestsAsync()
        {
            var interests =  await _repository.GetAllCategoriesWithInterestsAsync();

            return _mapper.Map<List<InterestsWithCategoriesResponse>>(interests);
        }
    }
}
