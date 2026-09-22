using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeeFriend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForCountriesAndCities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "Bulgaria" },
                    { 2, "Germany" },
                    { 3, "France" },
                    { 4, "Italy" },
                    { 5, "Spain" },
                    { 6, "United Kingdom" },
                    { 7, "Romania" },
                    { 8, "Greece" },
                    { 9, "Austria" },
                    { 10, "Netherlands" },
                    { 11, "Poland" },
                    { 12, "Czech Republic" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CountryId", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, 1, 42.697699999999998, 23.321899999999999, "Sofia" },
                    { 2, 1, 42.135399999999997, 24.7453, "Plovdiv" },
                    { 3, 1, 43.214100000000002, 27.9147, "Varna" },
                    { 4, 1, 42.504800000000003, 27.462599999999998, "Burgas" },
                    { 5, 2, 52.520000000000003, 13.404999999999999, "Berlin" },
                    { 6, 2, 48.135100000000001, 11.582000000000001, "Munich" },
                    { 7, 2, 53.551099999999998, 9.9937000000000005, "Hamburg" },
                    { 8, 2, 50.110900000000001, 8.6821000000000002, "Frankfurt" },
                    { 9, 3, 48.8566, 2.3521999999999998, "Paris" },
                    { 10, 3, 43.296500000000002, 5.3697999999999997, "Marseille" },
                    { 11, 3, 45.764000000000003, 4.8357000000000001, "Lyon" },
                    { 12, 4, 41.902799999999999, 12.4964, "Rome" },
                    { 13, 4, 45.464199999999998, 9.1899999999999995, "Milan" },
                    { 14, 4, 40.851799999999997, 14.2681, "Naples" },
                    { 15, 5, 40.416800000000002, -3.7038000000000002, "Madrid" },
                    { 16, 5, 41.385100000000001, 2.1734, "Barcelona" },
                    { 17, 5, 39.469900000000003, -0.37630000000000002, "Valencia" },
                    { 18, 6, 51.507399999999997, -0.1278, "London" },
                    { 19, 6, 53.480800000000002, -2.2425999999999999, "Manchester" },
                    { 20, 6, 52.486199999999997, -1.8904000000000001, "Birmingham" },
                    { 21, 7, 44.4268, 26.102499999999999, "Bucharest" },
                    { 22, 7, 46.7712, 23.6236, "Cluj-Napoca" },
                    { 23, 8, 37.983800000000002, 23.727499999999999, "Athens" },
                    { 24, 8, 40.640099999999997, 22.944400000000002, "Thessaloniki" },
                    { 25, 9, 48.208199999999998, 16.373799999999999, "Vienna" },
                    { 26, 9, 47.8095, 13.055, "Salzburg" },
                    { 27, 10, 52.367600000000003, 4.9040999999999997, "Amsterdam" },
                    { 28, 10, 51.924399999999999, 4.4776999999999996, "Rotterdam" },
                    { 29, 11, 52.229700000000001, 21.0122, "Warsaw" },
                    { 30, 11, 50.064700000000002, 19.945, "Krakow" },
                    { 31, 12, 50.075499999999998, 14.437799999999999, "Prague" },
                    { 32, 12, 49.195099999999996, 16.6068, "Brno" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 12);
        }
    }
}
