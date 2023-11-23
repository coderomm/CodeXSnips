using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeXSnips.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedCorrectApplicationUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserUsername",
                table: "AspNetUsers",
                newName: "FullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "UserUsername");
        }
    }
}
