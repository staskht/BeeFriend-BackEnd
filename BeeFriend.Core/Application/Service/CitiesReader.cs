
using AutoMapper;
using BeeFriend.Core.Domain.UnitOfWorkContract;
using BeeFriend.Core.Exceptions;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using BeeFriend.Core.Application.Results;

namespace BeeFriend.Core.Application.Service
{
    public class CitiesReader : IAllGetterByIdService<CityResponse, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CitiesReader(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<CityResponse>>> GetAllByIdAsync(int countryId) 
        {
            if (countryId <= 0)
                return Errors.Validation(
                    "CountryIdInvalid",
                    "CountryId must be greater than zero.");

            var country = await _unitOfWork.Countries.GetByIdAsync(countryId);

            if (country == null)
                return Errors.CountryNotFound;

            var cities = await _unitOfWork.Cities.GetAllByIdAsync(countryId);

            if (cities.Count == 0) 
                throw new CitiesNotFoundException("A valid country exists but has no cities.");

            return _mapper.Map<List<CityResponse>>(cities);
        }
    }
}
