using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeeFriend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InterestsAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interests",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTokenExpiryDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "InterestCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interests_InterestCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "InterestCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestUserProfile",
                columns: table => new
                {
                    InterestsInterestId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestUserProfile", x => new { x.InterestsInterestId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_InterestUserProfile_Interests_InterestsInterestId",
                        column: x => x.InterestsInterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestUserProfile_UserProfiles_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_CategoryId",
                table: "Interests",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestUserProfile_UsersUserId",
                table: "InterestUserProfile",
                column: "UsersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestUserProfile");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "InterestCategories");

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "UserProfiles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTokenExpiryDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
