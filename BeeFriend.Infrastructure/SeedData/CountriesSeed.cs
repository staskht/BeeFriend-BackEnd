using BeeFriend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeFriend.Infrastructure.SeedData
{
    internal static class CountriesSeed
    {
        public static readonly Country[] Countries =
        {
            new() { CountryId = 1, Name = "Bulgaria" },
            new() { CountryId = 2, Name = "Germany" },
            new() { CountryId = 3, Name = "France" },
            new() { CountryId = 4, Name = "Italy" },
            new() { CountryId = 5, Name = "Spain" },
            new() { CountryId = 6, Name = "United Kingdom" },
            new() { CountryId = 7, Name = "Romania" },
            new() { CountryId = 8, Name = "Greece" },
            new() { CountryId = 9, Name = "Austria" },
            new() { CountryId = 10, Name = "Netherlands" },
            new() { CountryId = 11, Name = "Poland" },
            new() { CountryId = 12, Name = "Czech Republic" },
        };
    }
}
