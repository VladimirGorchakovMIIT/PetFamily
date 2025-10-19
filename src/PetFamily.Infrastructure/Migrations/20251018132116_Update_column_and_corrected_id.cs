using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_column_and_corrected_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "volunteers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "species",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "pets",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "breeds",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "volunteers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "species",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "pets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "breeds",
                newName: "Id");
        }
    }
}
