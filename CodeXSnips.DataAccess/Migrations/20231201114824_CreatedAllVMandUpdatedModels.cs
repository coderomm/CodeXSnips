using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeXSnips.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreatedAllVMandUpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeImage",
                table: "CodeSnippets");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CodeSnippets");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "CodeSnippets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MediaPath",
                table: "CodeSnippets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "CodeSnippets");

            migrationBuilder.DropColumn(
                name: "MediaPath",
                table: "CodeSnippets");

            migrationBuilder.AddColumn<string>(
                name: "CodeImage",
                table: "CodeSnippets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CodeSnippets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
