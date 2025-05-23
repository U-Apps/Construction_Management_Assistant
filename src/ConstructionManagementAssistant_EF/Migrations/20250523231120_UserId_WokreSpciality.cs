using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementAssistant.EF.Migrations
{
    /// <inheritdoc />
    public partial class UserId_WokreSpciality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UniqueSpecialtyName",
                table: "WorkerSpecialties");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WorkerSpecialties",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_WorkerSpecialties_UserId",
                table: "WorkerSpecialties",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerSpecialties_Users_UserId",
                table: "WorkerSpecialties",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerSpecialties_Users_UserId",
                table: "WorkerSpecialties");

            migrationBuilder.DropIndex(
                name: "IX_WorkerSpecialties_UserId",
                table: "WorkerSpecialties");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WorkerSpecialties");

            migrationBuilder.CreateIndex(
                name: "UniqueSpecialtyName",
                table: "WorkerSpecialties",
                column: "Name",
                unique: true);
        }
    }
}
