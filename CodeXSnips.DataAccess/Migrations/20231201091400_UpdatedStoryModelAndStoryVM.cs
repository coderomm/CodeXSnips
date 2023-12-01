using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeXSnips.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStoryModelAndStoryVM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Stories");

            migrationBuilder.RenameColumn(
                name: "StoryMedia",
                table: "Stories",
                newName: "MediaPath");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Stories",
                type: "nvarchar(18)",
                maxLength: 18,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresAt",
                table: "Stories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "ExpiresAt",
                table: "Stories");

            migrationBuilder.RenameColumn(
                name: "MediaPath",
                table: "Stories",
                newName: "StoryMedia");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Stories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
