using AutoMapper;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using BeeFriend.Core.Domain.UnitOfWorkContract;

namespace BeeFriend.Core.Application.Service
{
    public class PersonalityReader :
        IGetterService<PersonalityResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonalityReader(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<PersonalityResponse>>> GetAllAsync()
        {
            var personalityTraits = await _unitOfWork.PersonalityTraits.GetAllAsync();

            return _mapper.Map<List<PersonalityResponse>>(personalityTraits);
        }
    }
}
