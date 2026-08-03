using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeFriend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCountryInUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "UserProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_CountryId",
                table: "UserProfiles",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Countries_CountryId",
                table: "UserProfiles",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Countries_CountryId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_CountryId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "UserProfiles");
        }
    }
}
