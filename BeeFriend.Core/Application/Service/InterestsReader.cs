using AutoMapper;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using BeeFriend.Core.Domain.UnitOfWorkContract;

namespace BeeFriend.Core.Application.Service
{
    public class InterestsReader :
        IGetterService<InterestsWithCategoriesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InterestsReader(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<InterestsWithCategoriesResponse>>> GetAllAsync()
        {
            var interests = await _unitOfWork.InterestCategories.GetAllAsync();

            return _mapper.Map<List<InterestsWithCategoriesResponse>>(interests);
        }
    }
}
