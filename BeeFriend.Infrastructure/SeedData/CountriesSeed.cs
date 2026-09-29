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
            new() { Id = 1, Name = "Bulgaria" },
            new() { Id = 2, Name = "Germany" },
            new() { Id = 3, Name = "France" },
            new() { Id = 4, Name = "Italy" },
            new() { Id = 5, Name = "Spain" },
            new() { Id = 6, Name = "United Kingdom" },
            new() { Id = 7, Name = "Romania" },
            new() { Id = 8, Name = "Greece" },
            new() { Id = 9, Name = "Austria" },
            new() { Id = 10, Name = "Netherlands" },
            new() { Id = 11, Name = "Poland" },
            new() { Id = 12, Name = "Czech Republic" },
        };
    }
}
