
using AutoMapper;
using BeeFriend.Core.Exceptions;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.ServiceContracts.CrudServiceContracts;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Core.Application.ServiceContracts;
using BeeFriend.Core.Domain.Entities;

namespace BeeFriend.Core.Application.Service
{
    public class CitiesService :
        ICitiesService
    {
        private readonly ICountriesService _countriesService;
        private readonly IMapper _mapper;
        private readonly ICitiesRepository _citiesRepository;

        public CitiesService(
            ICountriesService countriesService, 
            ICitiesRepository citiesRepository, 
            IMapper mapper) 
        {
            _mapper = mapper;
            _countriesService = countriesService;
            _citiesRepository = citiesRepository;
        }

        public async Task<Result<IEnumerable<CityResponse>>> GetAllByIdAsync(int countryId, CancellationToken cancellationToken) 
        {
            var result =  await _countriesService.GetByIdAsync(countryId, cancellationToken);

            if (result.IsFailure)
                return result.Error!;

            var cities = await _citiesRepository.GetAllByIdAsync(countryId, cancellationToken);

            if (cities.Count == 0) 
                throw new CitiesNotFoundException("A valid country exists but has no cities.");

            return _mapper.Map<List<CityResponse>>(cities);
        }

        public async Task<Result<City>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                return Errors.Validation(
                   "CityIdInvalid",
                   "CityId must be greater than zero.");

            var city = await _citiesRepository.GetByIdAsync(id, cancellationToken);

            if (city == null)
                return Errors.CityNotFound;

            return city;
        }
    }
}
