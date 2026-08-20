using AutoMapper;
using BeeFriend.Core.Domain.UnitOfWorkContract;
using BeeFriend.Core.DTO;
using BeeFriend.Core.Results;
using BeeFriend.Core.ServiceContracts.CrudServiceContracts;

namespace BeeFriend.Core.Service
{
    public class CountriesReader : 
        IAllReaderService<CountryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountriesReader(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<CountryResponse>>> GetAllAsync()
        {
            var countries = 
                await _unitOfWork.Countries.GetAllAsync();

            return _mapper.Map<List<CountryResponse>>(countries);
        }
    }
}
