using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "species",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title_Value = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_species", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "volunteer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    fullName_Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    fullName_Surname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    fullName_Patronymic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    description_Value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    phoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    requisites_Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    requisites_Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    VolunteerDetails = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_volunteer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "breed",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title_Value = table.Column<string>(type: "text", nullable: true),
                    species_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_breed", x => x.id);
                    table.ForeignKey(
                        name: "fK_breed_species_species_id",
                        column: x => x.species_id,
                        principalTable: "species",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pet",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nickname = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    description_Value = table.Column<string>(type: "text", nullable: true),
                    specifications_Height = table.Column<float>(type: "real", nullable: true),
                    specifications_Weight = table.Column<float>(type: "real", nullable: true),
                    specifications_Color = table.Column<int>(type: "integer", nullable: true),
                    specifications_HealthInformation = table.Column<string>(type: "text", nullable: true),
                    breed = table.Column<string>(type: "text", nullable: false),
                    phoneNumber = table.Column<string>(type: "text", nullable: false),
                    isNeutered = table.Column<bool>(type: "boolean", nullable: false),
                    birthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    isVaccinated = table.Column<bool>(type: "boolean", nullable: false),
                    isFoundedHouse = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    dateCreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    sharedLinks_SpeciesId = table.Column<Guid>(type: "uuid", nullable: true),
                    sharedLinks_BreedId = table.Column<Guid>(type: "uuid", nullable: true),
                    volunteer_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_pet", x => x.id);
                    table.ForeignKey(
                        name: "fK_pet_volunteer_volunteer_id",
                        column: x => x.volunteer_id,
                        principalTable: "volunteer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "iX_breed_species_id",
                table: "breed",
                column: "species_id");

            migrationBuilder.CreateIndex(
                name: "iX_pet_volunteer_id",
                table: "pet",
                column: "volunteer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "breed");

            migrationBuilder.DropTable(
                name: "pet");

            migrationBuilder.DropTable(
                name: "species");

            migrationBuilder.DropTable(
                name: "volunteer");
        }
    }
}
