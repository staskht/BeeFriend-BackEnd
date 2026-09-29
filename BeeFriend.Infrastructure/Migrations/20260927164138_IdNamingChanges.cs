using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeFriend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IdNamingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendshipPreferenceUserProfile_FriendshipPreferences_FriendshipPreferencesPreferenceId",
                table: "FriendshipPreferenceUserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendshipPreferenceUserProfile_UserProfiles_UsersUserId",
                table: "FriendshipPreferenceUserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestUserProfile_Interests_InterestsInterestId",
                table: "InterestUserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestUserProfile_UserProfiles_UsersUserId",
                table: "InterestUserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalityUserProfile_PersonalityTraits_PersonalityTraitsPerosnalityId",
                table: "PersonalityUserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalityUserProfile_UserProfiles_UsersUserId",
                table: "PersonalityUserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_AspNetUsers_UserId",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserProfiles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "PersonalityUserProfile",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "PersonalityTraitsPerosnalityId",
                table: "PersonalityUserProfile",
                newName: "PersonalityTraitsId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalityUserProfile_UsersUserId",
                table: "PersonalityUserProfile",
                newName: "IX_PersonalityUserProfile_UsersId");

            migrationBuilder.RenameColumn(
                name: "PerosnalityId",
                table: "PersonalityTraits",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "InterestUserProfile",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "InterestsInterestId",
                table: "InterestUserProfile",
                newName: "InterestsId");

            migrationBuilder.RenameIndex(
                name: "IX_InterestUserProfile_UsersUserId",
                table: "InterestUserProfile",
                newName: "IX_InterestUserProfile_UsersId");

            migrationBuilder.RenameColumn(
                name: "InterestId",
                table: "Interests",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "InterestCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "FriendshipPreferenceUserProfile",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "FriendshipPreferencesPreferenceId",
                table: "FriendshipPreferenceUserProfile",
                newName: "FriendshipPreferencesId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendshipPreferenceUserProfile_UsersUserId",
                table: "FriendshipPreferenceUserProfile",
                newName: "IX_FriendshipPreferenceUserProfile_UsersId");

            migrationBuilder.RenameColumn(
                name: "PreferenceId",
                table: "FriendshipPreferences",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Countries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Cities",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendshipPreferenceUserProfile_FriendshipPreferences_FriendshipPreferencesId",
                table: "FriendshipPreferenceUserProfile",
                column: "FriendshipPreferencesId",
                principalTable: "FriendshipPreferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendshipPreferenceUserProfile_UserProfiles_UsersId",
                table: "FriendshipPreferenceUserProfile",
                column: "UsersId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestUserProfile_Interests_InterestsId",
                table: "InterestUserProfile",
                column: "InterestsId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestUserProfile_UserProfiles_UsersId",
                table: "InterestUserProfile",
                column: "UsersId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalityUserProfile_PersonalityTraits_PersonalityTraitsId",
                table: "PersonalityUserProfile",
                column: "PersonalityTraitsId",
                principalTable: "PersonalityTraits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalityUserProfile_UserProfiles_UsersId",
                table: "PersonalityUserProfile",
                column: "UsersId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_AspNetUsers_Id",
                table: "UserProfiles",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendshipPreferenceUserProfile_FriendshipPreferences_FriendshipPreferencesId",
                table: "FriendshipPreferenceUserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendshipPreferenceUserProfile_UserProfiles_UsersId",
                table: "FriendshipPreferenceUserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestUserProfile_Interests_InterestsId",
                table: "InterestUserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestUserProfile_UserProfiles_UsersId",
                table: "InterestUserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalityUserProfile_PersonalityTraits_PersonalityTraitsId",
                table: "PersonalityUserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalityUserProfile_UserProfiles_UsersId",
                table: "PersonalityUserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_AspNetUsers_Id",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserProfiles",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "PersonalityUserProfile",
                newName: "UsersUserId");

            migrationBuilder.RenameColumn(
                name: "PersonalityTraitsId",
                table: "PersonalityUserProfile",
                newName: "PersonalityTraitsPerosnalityId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalityUserProfile_UsersId",
                table: "PersonalityUserProfile",
                newName: "IX_PersonalityUserProfile_UsersUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PersonalityTraits",
                newName: "PerosnalityId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "InterestUserProfile",
                newName: "UsersUserId");

            migrationBuilder.RenameColumn(
                name: "InterestsId",
                table: "InterestUserProfile",
                newName: "InterestsInterestId");

            migrationBuilder.RenameIndex(
                name: "IX_InterestUserProfile_UsersId",
                table: "InterestUserProfile",
                newName: "IX_InterestUserProfile_UsersUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Interests",
                newName: "InterestId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InterestCategories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "FriendshipPreferenceUserProfile",
                newName: "UsersUserId");

            migrationBuilder.RenameColumn(
                name: "FriendshipPreferencesId",
                table: "FriendshipPreferenceUserProfile",
                newName: "FriendshipPreferencesPreferenceId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendshipPreferenceUserProfile_UsersId",
                table: "FriendshipPreferenceUserProfile",
                newName: "IX_FriendshipPreferenceUserProfile_UsersUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FriendshipPreferences",
                newName: "PreferenceId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Countries",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cities",
                newName: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendshipPreferenceUserProfile_FriendshipPreferences_FriendshipPreferencesPreferenceId",
                table: "FriendshipPreferenceUserProfile",
                column: "FriendshipPreferencesPreferenceId",
                principalTable: "FriendshipPreferences",
                principalColumn: "PreferenceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendshipPreferenceUserProfile_UserProfiles_UsersUserId",
                table: "FriendshipPreferenceUserProfile",
                column: "UsersUserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestUserProfile_Interests_InterestsInterestId",
                table: "InterestUserProfile",
                column: "InterestsInterestId",
                principalTable: "Interests",
                principalColumn: "InterestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestUserProfile_UserProfiles_UsersUserId",
                table: "InterestUserProfile",
                column: "UsersUserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalityUserProfile_PersonalityTraits_PersonalityTraitsPerosnalityId",
                table: "PersonalityUserProfile",
                column: "PersonalityTraitsPerosnalityId",
                principalTable: "PersonalityTraits",
                principalColumn: "PerosnalityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalityUserProfile_UserProfiles_UsersUserId",
                table: "PersonalityUserProfile",
                column: "UsersUserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_AspNetUsers_UserId",
                table: "UserProfiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
