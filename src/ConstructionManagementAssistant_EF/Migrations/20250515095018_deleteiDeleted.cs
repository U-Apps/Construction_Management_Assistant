using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementAssistant.EF.Migrations
{
    /// <inheritdoc />
    public partial class deleteiDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "WorkerSpecialties");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "WorkerSpecialties");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Stages",
                newName: "ExpectedEndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpectedEndDate",
                table: "Stages",
                newName: "EndDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "WorkerSpecialties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "WorkerSpecialties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeletedDate", "IsDeleted" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeletedDate", "IsDeleted" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeletedDate", "IsDeleted" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DeletedDate", "IsDeleted" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DeletedDate", "IsDeleted" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DeletedDate", "IsDeleted" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DeletedDate", "IsDeleted" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DeletedDate", "IsDeleted" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DeletedDate", "IsDeleted" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DeletedDate", "IsDeleted" },
                values: new object[] { null, false });
        }
    }
}
