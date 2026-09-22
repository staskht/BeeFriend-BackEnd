using AutoMapper;
using BeeFriend.Core.Application.DTO.InterestDTOs;
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
    public class InterestsService : 
        CrudService<
            Interest, 
            InterestRequest, 
            InterestResponse, 
            int, 
            IRepository<Interest, int>>
    {
        private readonly IInterestCategoriesRepository _interestCategoriesRepository;
        public InterestsService(
            IRepository<Interest, int> repository, 
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            IInterestCategoriesRepository interestCategoriesRepository) : 
            base(repository, mapper, unitOfWork)
        {
            _interestCategoriesRepository = interestCategoriesRepository;
        }

        public override async Task<Result<InterestResponse>> AddAsync(InterestRequest requestDto)
        {
            var category = 
                await _interestCategoriesRepository.GetByIdAsync(requestDto.CategoryId);

            if (category == null)
                return Errors.EntityNotFound("CategoryNotFound", "Category with such id doesnt exist");

            return await base.AddAsync(requestDto);
        }

        public override async Task<Result<InterestResponse>> UpdateAsync(int id, InterestRequest requestDto)
        {
            var category =
                await _interestCategoriesRepository.GetByIdAsync(requestDto.CategoryId);

            if (category == null)
                return Errors.EntityNotFound("CategoryNotFound", "Category with such id doesnt exist");

            return await base.UpdateAsync(id, requestDto);
        }
    }
}
