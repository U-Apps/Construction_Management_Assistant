using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementAssistant.EF.Migrations
{
    /// <inheritdoc />
    public partial class ReservationStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationStatus",
                table: "EquipmentReservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddCheckConstraint(
                name: "CK_EquipmentReservations_ReservationStatus",
                table: "EquipmentReservations",
                sql: "[ReservationStatus] BETWEEN 0 AND 3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_EquipmentReservations_ReservationStatus",
                table: "EquipmentReservations");

            migrationBuilder.DropColumn(
                name: "ReservationStatus",
                table: "EquipmentReservations");
        }
    }
}
