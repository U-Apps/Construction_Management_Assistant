using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementAssistant.EF.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UniqueTitle",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "UniqueType",
                table: "DocumentClassifications");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Documents",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DocumentType",
                table: "DocumentClassifications",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "UploadedBy",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "UniqueTitle",
                table: "Documents",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UniqueType",
                table: "DocumentClassifications",
                column: "Type",
                unique: true,
                filter: "[Type] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UniqueTitle",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "UniqueType",
                table: "DocumentClassifications");

            migrationBuilder.DropColumn(
                name: "UploadedBy",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Documents",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "DocumentClassifications",
                newName: "DocumentType");

            migrationBuilder.CreateIndex(
                name: "UniqueTitle",
                table: "Documents",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UniqueType",
                table: "DocumentClassifications",
                column: "DocumentType",
                unique: true,
                filter: "[DocumentType] IS NOT NULL");
        }
    }
}
