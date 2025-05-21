using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConstructionManagementAssistant.EF.Migrations
{
    /// <inheritdoc />
    public partial class deleteDocClassifcatio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentClassifications_ClassificationId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentClassifications");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ClassificationId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ClassificationId",
                table: "Documents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassificationId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DocumentClassifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentClassifications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DocumentClassifications",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Project Documents" },
                    { 2, "Design Documents" },
                    { 3, "Engineering & Technical Documents" },
                    { 4, "Legal & Compliance Documents" },
                    { 5, "Financial Documents" },
                    { 6, "Site & Execution Documents" },
                    { 7, "HR & Administrative Documents" },
                    { 8, "Quality Assurance & Control Documents" },
                    { 9, "Health, Safety, and Environment (HSE) Documents" },
                    { 10, "Close-Out & Handover Documents" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ClassificationId",
                table: "Documents",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "UniqueType",
                table: "DocumentClassifications",
                column: "Type",
                unique: true,
                filter: "[Type] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentClassifications_ClassificationId",
                table: "Documents",
                column: "ClassificationId",
                principalTable: "DocumentClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
