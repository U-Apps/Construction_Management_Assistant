using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementAssistant_EF.Migrations
{
    /// <inheritdoc />
    public partial class adduniqueconstraintoEmailandPhoneNumberinclienttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "UniqueEmail",
                table: "tbClient",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UniquePhoneNumber",
                table: "tbClient",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UniqueEmail",
                table: "tbClient");

            migrationBuilder.DropIndex(
                name: "UniquePhoneNumber",
                table: "tbClient");
        }
    }
}
