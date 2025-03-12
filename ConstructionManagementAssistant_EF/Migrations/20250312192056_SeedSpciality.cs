using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConstructionManagementAssistant_EF.Migrations
{
    /// <inheritdoc />
    public partial class SeedSpciality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkerSpecialties",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "نجار" },
                    { 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "حداد" },
                    { 3, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "سباك" },
                    { 4, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "كهربائي" },
                    { 5, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "بناء" },
                    { 6, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "دهان" },
                    { 7, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "مبلط" },
                    { 8, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "مقاول" },
                    { 9, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "مهندس معماري" },
                    { 10, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "مهندس مدني" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
