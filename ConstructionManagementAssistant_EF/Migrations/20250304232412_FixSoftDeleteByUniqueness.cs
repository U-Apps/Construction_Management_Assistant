using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementAssistant_EF.Migrations
{
    /// <inheritdoc />
    public partial class FixSoftDeleteByUniqueness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UniqueSpecialtyName",
                table: "WorkerSpecialties");

            migrationBuilder.DropIndex(
                name: "UniqueEmail",
                table: "People");

            migrationBuilder.DropIndex(
                name: "UniqueNationalNumber",
                table: "People");

            migrationBuilder.DropIndex(
                name: "UniquePhoneNumber",
                table: "People");

            migrationBuilder.DropIndex(
                name: "UniqueEmail",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "UniquePhoneNumber",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "UniqueSpecialtyName",
                table: "WorkerSpecialties",
                column: "Name",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "UniqueEmail",
                table: "People",
                column: "Email",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "UniqueNationalNumber",
                table: "People",
                column: "NationalNumber",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "UniquePhoneNumber",
                table: "People",
                column: "PhoneNumber",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "UniqueEmail",
                table: "Clients",
                column: "Email",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "UniquePhoneNumber",
                table: "Clients",
                column: "PhoneNumber",
                unique: true,
                filter: "[IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UniqueSpecialtyName",
                table: "WorkerSpecialties");

            migrationBuilder.DropIndex(
                name: "UniqueEmail",
                table: "People");

            migrationBuilder.DropIndex(
                name: "UniqueNationalNumber",
                table: "People");

            migrationBuilder.DropIndex(
                name: "UniquePhoneNumber",
                table: "People");

            migrationBuilder.DropIndex(
                name: "UniqueEmail",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "UniquePhoneNumber",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "UniqueSpecialtyName",
                table: "WorkerSpecialties",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UniqueEmail",
                table: "People",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UniqueNationalNumber",
                table: "People",
                column: "NationalNumber",
                unique: true,
                filter: "[NationalNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UniquePhoneNumber",
                table: "People",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UniqueEmail",
                table: "Clients",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UniquePhoneNumber",
                table: "Clients",
                column: "PhoneNumber",
                unique: true);
        }
    }
}
