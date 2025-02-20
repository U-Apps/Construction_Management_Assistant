using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementAssistant_EF.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Startdate = table.Column<DateOnly>(type: "date", nullable: false),
                    ExpectedEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SiteEngineerId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    SiteAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GeographicalCoordinates = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateModified = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "GETDATE()"),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "GETDATE()"),
                    CancelationReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CancelationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CancelledAtStage = table.Column<int>(type: "int", nullable: true),
                    CompletionDate = table.Column<DateOnly>(type: "date", nullable: true),
                    HandoverDate = table.Column<DateOnly>(type: "date", nullable: true),
                    //SiteEngineerId1 = table.Column<int>(type: "int", nullable: false),
                    //ClientId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.CheckConstraint("CK_Projects_Status", "[Status] BETWEEN 0 AND 4");
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_SiteEngineers_SiteEngineerId",
                        column: x => x.SiteEngineerId,
                        principalTable: "SiteEngineers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId",
                unique: true);


            migrationBuilder.CreateIndex(
                name: "IX_Projects_SiteEngineerId",
                table: "Projects",
                column: "SiteEngineerId",
                unique: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
