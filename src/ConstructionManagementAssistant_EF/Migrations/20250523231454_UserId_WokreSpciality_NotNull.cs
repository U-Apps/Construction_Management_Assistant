using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementAssistant.EF.Migrations
{
    /// <inheritdoc />
    public partial class UserId_WokreSpciality_NotNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerSpecialties_Users_UserId",
                table: "WorkerSpecialties");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WorkerSpecialties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerSpecialties_Users_UserId",
                table: "WorkerSpecialties",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerSpecialties_Users_UserId",
                table: "WorkerSpecialties");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WorkerSpecialties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerSpecialties_Users_UserId",
                table: "WorkerSpecialties",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
