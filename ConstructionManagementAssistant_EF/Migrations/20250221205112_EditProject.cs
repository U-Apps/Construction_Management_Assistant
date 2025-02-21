using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementAssistant_EF.Migrations
{
    /// <inheritdoc />
    public partial class EditProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "Startdate",
                table: "Projects",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Projects",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Projects",
                newName: "Startdate");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateCreated",
                table: "Projects",
                type: "date",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateModified",
                table: "Projects",
                type: "date",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }
    }
}
