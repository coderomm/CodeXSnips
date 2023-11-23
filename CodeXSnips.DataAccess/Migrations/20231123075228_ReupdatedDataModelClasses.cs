using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeXSnips.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ReupdatedDataModelClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodeSnippets_CodeReels_CodeReelId",
                table: "CodeSnippets");

            migrationBuilder.DropIndex(
                name: "IX_CodeSnippets_CodeReelId",
                table: "CodeSnippets");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "CodeReelId",
                table: "CodeSnippets");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "CodeSnippets");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "CodeSnippets");

            migrationBuilder.RenameColumn(
                name: "ImageMimeType",
                table: "CodeSnippets",
                newName: "CodeImage");

            migrationBuilder.AddColumn<string>(
                name: "StoryMedia",
                table: "Stories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodeReelVideo",
                table: "CodeReels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoryMedia",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "CodeReelVideo",
                table: "CodeReels");

            migrationBuilder.RenameColumn(
                name: "CodeImage",
                table: "CodeSnippets",
                newName: "ImageMimeType");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Stories",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CodeReelId",
                table: "CodeSnippets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "CodeSnippets",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "CodeSnippets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CodeSnippets_CodeReelId",
                table: "CodeSnippets",
                column: "CodeReelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CodeSnippets_CodeReels_CodeReelId",
                table: "CodeSnippets",
                column: "CodeReelId",
                principalTable: "CodeReels",
                principalColumn: "CodeReelId");
        }
    }
}
