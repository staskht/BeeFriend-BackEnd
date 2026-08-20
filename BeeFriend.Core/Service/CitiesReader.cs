
using AutoMapper;
using BeeFriend.Core.Domain.UnitOfWorkContract;
using BeeFriend.Core.DTO;
using BeeFriend.Core.Results;
using BeeFriend.Core.ServiceContracts.CrudServiceContracts;
using BeeFriend.Core.Exceptions;

namespace BeeFriend.Core.Service
{
    public class CitiesReader : IAllReaderService<CityResponse, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CitiesReader(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<CityResponse>>> GetAllAsync(int countryId) 
        {
            var cities =
                await _unitOfWork.Cities.GetAllByCountryIdAsync(countryId);

            if (cities.Count == 0)
            {
                throw new CitiesNotFoundException("Database call for cities cannot return empty collection");
            }

            if (countryId < 0 || countryId > cities.Count())
            {
                return Errors.Validation("CountryIdOutOfRange", "Value must be a valid country id.");
            }

            return _mapper.Map<List<CityResponse>>(cities);
        }
    }
}
