using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeFriend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInterestsPersonaltyandFreindhShipPreferencestables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Interests",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "InterestCategories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "FriendshipPreferences",
                columns: table => new
                {
                    PreferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendshipPreferences", x => x.PreferenceId);
                });

            migrationBuilder.CreateTable(
                name: "PersonalityTraits",
                columns: table => new
                {
                    PerosnalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalityTraits", x => x.PerosnalityId);
                });

            migrationBuilder.CreateTable(
                name: "FriendshipPreferenceUserProfile",
                columns: table => new
                {
                    FriendshipPreferencesPreferenceId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendshipPreferenceUserProfile", x => new { x.FriendshipPreferencesPreferenceId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_FriendshipPreferenceUserProfile_FriendshipPreferences_FriendshipPreferencesPreferenceId",
                        column: x => x.FriendshipPreferencesPreferenceId,
                        principalTable: "FriendshipPreferences",
                        principalColumn: "PreferenceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendshipPreferenceUserProfile_UserProfiles_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalityUserProfile",
                columns: table => new
                {
                    PersonalityTraitsPerosnalityId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalityUserProfile", x => new { x.PersonalityTraitsPerosnalityId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_PersonalityUserProfile_PersonalityTraits_PersonalityTraitsPerosnalityId",
                        column: x => x.PersonalityTraitsPerosnalityId,
                        principalTable: "PersonalityTraits",
                        principalColumn: "PerosnalityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalityUserProfile_UserProfiles_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendshipPreferenceUserProfile_UsersUserId",
                table: "FriendshipPreferenceUserProfile",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalityUserProfile_UsersUserId",
                table: "PersonalityUserProfile",
                column: "UsersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendshipPreferenceUserProfile");

            migrationBuilder.DropTable(
                name: "PersonalityUserProfile");

            migrationBuilder.DropTable(
                name: "FriendshipPreferences");

            migrationBuilder.DropTable(
                name: "PersonalityTraits");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Interests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "InterestCategories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
