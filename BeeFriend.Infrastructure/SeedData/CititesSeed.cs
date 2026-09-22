using BeeFriend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Infrastructure.SeedData
{
    internal static class CititesSeed
    {
        public static readonly City[] Cities =
        {
            // Bulgaria
            new()
            {
                CityId = 1,
                Name = "Sofia",
                CountryId = 1,
                Latitude = 42.6977,
                Longitude = 23.3219
            },
            new()
            {
                CityId = 2,
                Name = "Plovdiv",
                CountryId = 1,
                Latitude = 42.1354,
                Longitude = 24.7453
            },
            new()
            {
                CityId = 3,
                Name = "Varna",
                CountryId = 1,
                Latitude = 43.2141,
                Longitude = 27.9147
            },
            new()
            {
                CityId = 4,
                Name = "Burgas",
                CountryId = 1,
                Latitude = 42.5048,
                Longitude = 27.4626
            },

            // Germany
            new()
            {
                CityId = 5,
                Name = "Berlin",
                CountryId = 2,
                Latitude = 52.5200,
                Longitude = 13.4050
            },
            new()
            {
                CityId = 6,
                Name = "Munich",
                CountryId = 2,
                Latitude = 48.1351,
                Longitude = 11.5820
            },
            new()
            {
                CityId = 7,
                Name = "Hamburg",
                CountryId = 2,
                Latitude = 53.5511,
                Longitude = 9.9937
            },
            new()
            {
                CityId = 8,
                Name = "Frankfurt",
                CountryId = 2,
                Latitude = 50.1109,
                Longitude = 8.6821
            },

            // France
            new()
            {
                CityId = 9,
                Name = "Paris",
                CountryId = 3,
                Latitude = 48.8566,
                Longitude = 2.3522
            },
            new()
            {
                CityId = 10,
                Name = "Marseille",
                CountryId = 3,
                Latitude = 43.2965,
                Longitude = 5.3698
            },
            new()
            {
                CityId = 11,
                Name = "Lyon",
                CountryId = 3,
                Latitude = 45.7640,
                Longitude = 4.8357
            },

            // Italy
            new()
            {
                CityId = 12,
                Name = "Rome",
                CountryId = 4,
                Latitude = 41.9028,
                Longitude = 12.4964
            },
            new()
            {
                CityId = 13,
                Name = "Milan",
                CountryId = 4,
                Latitude = 45.4642,
                Longitude = 9.1900
            },
            new()
            {
                CityId = 14,
                Name = "Naples",
                CountryId = 4,
                Latitude = 40.8518,
                Longitude = 14.2681
            },

            // Spain
            new()
            {
                CityId = 15,
                Name = "Madrid",
                CountryId = 5,
                Latitude = 40.4168,
                Longitude = -3.7038
            },
            new()
            {
                CityId = 16,
                Name = "Barcelona",
                CountryId = 5,
                Latitude = 41.3851,
                Longitude = 2.1734
            },
            new()
            {
                CityId = 17,
                Name = "Valencia",
                CountryId = 5,
                Latitude = 39.4699,
                Longitude = -0.3763
            },

            // United Kingdom
            new()
            {
                CityId = 18,
                Name = "London",
                CountryId = 6,
                Latitude = 51.5074,
                Longitude = -0.1278
            },
            new()
            {
                CityId = 19,
                Name = "Manchester",
                CountryId = 6,
                Latitude = 53.4808,
                Longitude = -2.2426
            },
            new()
            {
                CityId = 20,
                Name = "Birmingham",
                CountryId = 6,
                Latitude = 52.4862,
                Longitude = -1.8904
            },

            // Romania
            new()
            {
                CityId = 21,
                Name = "Bucharest",
                CountryId = 7,
                Latitude = 44.4268,
                Longitude = 26.1025
            },
            new()
            {
                CityId = 22,
                Name = "Cluj-Napoca",
                CountryId = 7,
                Latitude = 46.7712,
                Longitude = 23.6236
            },

            // Greece
            new()
            {
                CityId = 23,
                Name = "Athens",
                CountryId = 8,
                Latitude = 37.9838,
                Longitude = 23.7275
            },
            new()
            {
                CityId = 24,
                Name = "Thessaloniki",
                CountryId = 8,
                Latitude = 40.6401,
                Longitude = 22.9444
            },

            // Austria
            new()
            {
                CityId = 25,
                Name = "Vienna",
                CountryId = 9,
                Latitude = 48.2082,
                Longitude = 16.3738
            },
            new()
            {
                CityId = 26,
                Name = "Salzburg",
                CountryId = 9,
                Latitude = 47.8095,
                Longitude = 13.0550
            },

            // Netherlands
            new()
            {
                CityId = 27,
                Name = "Amsterdam",
                CountryId = 10,
                Latitude = 52.3676,
                Longitude = 4.9041
            },
            new()
            {
                CityId = 28,
                Name = "Rotterdam",
                CountryId = 10,
                Latitude = 51.9244,
                Longitude = 4.4777
            },

            // Poland
            new()
            {
                CityId = 29,
                Name = "Warsaw",
                CountryId = 11,
                Latitude = 52.2297,
                Longitude = 21.0122
            },
            new()
            {
                CityId = 30,
                Name = "Krakow",
                CountryId = 11,
                Latitude = 50.0647,
                Longitude = 19.9450
            },

            // Czech Republic
            new()
            {
                CityId = 31,
                Name = "Prague",
                CountryId = 12,
                Latitude = 50.0755,
                Longitude = 14.4378
            },
            new()
            {
                CityId = 32,
                Name = "Brno",
                CountryId = 12,
                Latitude = 49.1951,
                Longitude = 16.6068
            }
        };
    }
}
