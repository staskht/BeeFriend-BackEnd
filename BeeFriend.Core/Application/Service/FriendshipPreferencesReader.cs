using AutoMapper;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using BeeFriend.Core.Domain.UnitOfWorkContract;

namespace BeeFriend.Core.Application.Service
{
    public class FriendshipPreferencesReader :
        IGetterService<FriendshipPreferenceResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FriendshipPreferencesReader(
            IUnitOfWork unitOfWork, 
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<FriendshipPreferenceResponse>>> GetAllAsync()
        {
            var preferences = await _unitOfWork.FriendshipPreferences.GetAllAsync();

            return _mapper.Map<List<FriendshipPreferenceResponse>>(preferences);
        }
    }
}
