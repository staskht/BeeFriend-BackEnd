using AutoMapper;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using BeeFriend.Core.Domain.UnitOfWorkContract;

namespace BeeFriend.Core.Application.Service
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
