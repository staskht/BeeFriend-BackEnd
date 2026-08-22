using AutoMapper;
using BeeFriend.Core.Application.DTO;
using BeeFriend.Core.Application.Results;
using BeeFriend.Core.Application.Service;
using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Core.Domain.UnitOfWorkContract;
using BeeFriend.Core.Exceptions;
using BeeFriend.Infrastructure.DbContext;
using BeeFriend.Infrastructure.UnitOfWork;
using EntityFrameworkCoreMock;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BeeFriend.CoreTest
{
    public class CitiesReaderTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<ICountriesRepository> _countriesRepositoryMock;
        private readonly Mock<ICitiesRepository> _citiesRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        private readonly CitiesReader _citiesReader;

        public CitiesReaderTest()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _countriesRepositoryMock = new Mock<ICountriesRepository>();
            _citiesRepositoryMock = new Mock<ICitiesRepository>();
            _mapperMock = new Mock<IMapper>();

            _unitOfWorkMock
                .Setup(x => x.Countries)
                .Returns(_countriesRepositoryMock.Object);

            _unitOfWorkMock
                .Setup(x => x.Cities)
                .Returns(_citiesRepositoryMock.Object);

            _citiesReader = new CitiesReader(
                _unitOfWorkMock.Object,
                _mapperMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_InvalidCountryId_ReturnsValidationError()
        {
            // Act
            var result = await _citiesReader.GetAllAsync(0);

            // Assert
            result.Error.Should().Be(Errors.Validation(
                "CountryIdInvalid",
                "CountryId must be greater than zero."));
        }

        [Fact]
        public async Task GetAllAsync_CountryDoesNotExist_ReturnsCountryNotFound()
        {
            // Arrange
            _countriesRepositoryMock
                .Setup(x => x.GetByIdAsync(5))
                .ReturnsAsync((Country?)null);

            // Act
            var result = await _citiesReader.GetAllAsync(5);

            // Assert
            result.Error.Should().Be(Errors.CountryNotFound);
        }

        [Fact]
        public async Task GetAllAsync_CitiesNotFound_ReturnsCitiesNotFoundException()
        {
            //Arrange
            var country = new Country()
            {
                CountryId = 5,
            };

            _countriesRepositoryMock
                .Setup(x => x.GetByIdAsync(5))
                .ReturnsAsync(country);

            _citiesRepositoryMock
                .Setup(x => x.GetAllByIdAsync(5))
                .ReturnsAsync(new List<City>() { });

            //Assert
            await FluentActions
                .Invoking(() => _citiesReader.GetAllAsync(5))
                .Should()
                .ThrowAsync<CitiesNotFoundException>("A valid country exists but has no cities.");
        }

        [Fact]
        public async Task GetAllAsync_CitiesExist_ReturnsCityResponses()
        {
            // Arrange
            var countryMock = new Mock<Country>();

            var city1 = new City
            {
                CityId = 1,
                Name = "Sofia"
            };

            var city2 = new City
            {
                CityId = 2,
                Name = "Plovdiv"
            };

            var cities = new List<City>
            {
                city1,
                city2
            };

            var cityResponses = new List<CityResponse>
            {
                new CityResponse(city1.CityId, city1.Name),
                new CityResponse(city2.CityId, city2.Name)
            };

            _countriesRepositoryMock
                .Setup(x => x.GetByIdAsync(5))
                .ReturnsAsync(countryMock.Object);

            _citiesRepositoryMock
                .Setup(x => x.GetAllByIdAsync(5))
                .ReturnsAsync(cities);

            _mapperMock
                .Setup(x => x.Map<List<CityResponse>>(cities))
                .Returns(cityResponses);

            // Act
            var result = await _citiesReader.GetAllAsync(5);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(cityResponses);
        }
    }


}
