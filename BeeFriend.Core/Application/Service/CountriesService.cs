using AutoMapper;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.ServiceContracts;
using BeeFriend.Core.Domain.RepositoryContracts;

namespace BeeFriend.Core.Application.Service
{
    public class CountriesService : 
        ICountriesService
    {
        private readonly ICountriesRepository _countriesRepository;
        private readonly IMapper _mapper;

        public CountriesService(ICountriesRepository countriesRepository, IMapper mapper)
        {
            _countriesRepository = countriesRepository;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<CountryResponse>>> GetAllAsync()
        {
            var countries = await _countriesRepository.GetAllAsync();

            return _mapper.Map<List<CountryResponse>>(countries);
        }

        public async Task<Result> ExistsAsync(int countryId)
        {
            if (countryId <= 0)
                return Errors.Validation(
                    "CountryIdInvalid",
                    "CountryId must be greater than zero.");

            var country = await _countriesRepository.GetByIdAsync(countryId);

            if (country == null)
                return Errors.CountryNotFound;

            return Result.Success();
        }
    }
}
