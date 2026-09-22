
using AutoMapper;
using BeeFriend.Core.Exceptions;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Core.Application.ServiceContracts;

namespace BeeFriend.Core.Application.Service
{
    public class CitiesReader : 
        ICitiesReader
    {
        private readonly ICountriesService _countriesService;
        private readonly IMapper _mapper;
        private readonly ICitiesRepository _citiesRepository;

        public CitiesReader(ICountriesService countriesService, ICitiesRepository citiesRepository, IMapper mapper) 
        {
            _mapper = mapper;
            _countriesService = countriesService;
            _citiesRepository = citiesRepository;
        }

        public async Task<Result<IEnumerable<CityResponse>>> GetAllByIdAsync(int countryId) 
        {
            var result =  await _countriesService.ExistsAsync(countryId);

            if (result.IsFailure)
                return result.Error!;

            var cities = await _citiesRepository.GetAllByIdAsync(countryId);

            if (cities.Count == 0) 
                throw new CitiesNotFoundException("A valid country exists but has no cities.");

            return _mapper.Map<List<CityResponse>>(cities);
        }
    }
}
