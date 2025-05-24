using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConstructionManagementAssistant.EF.Migrations
{
    /// <inheritdoc />
    public partial class deletSiteEngineer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_SiteEngineers_SiteEngineerId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "SiteEngineers");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.AddColumn<int>(
                name: "BelongToUserId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 7,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 8,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 9,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 10,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 11,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 12,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 13,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 14,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 15,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 16,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 17,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 18,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 19,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 20,
                column: "SiteEngineerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BelongToUserId",
                value: null);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BelongToUserId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 21, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "ahmed.engineer@example.com", true, false, null, "أحمد محمد", "AHMED.ENGINEER@EXAMPLE.COM", "AHMED.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "01553156789", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "ahmed.engineer" },
                    { 22, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "sara.engineer@example.com", true, false, null, "سارة علي", "SARA.ENGINEER@EXAMPLE.COM", "SARA.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "0987254321", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "sara.engineer" },
                    { 23, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "mohamed.engineer@example.com", true, false, null, "محمد حسن", "MOHAMED.ENGINEER@EXAMPLE.COM", "MOHAMED.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "0112233445", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "mohamed.engineer" },
                    { 24, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "leila.engineer@example.com", true, false, null, "ليلى إبراهيم", "LEILA.ENGINEER@EXAMPLE.COM", "LEILA.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "0223344556", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "leila.engineer" },
                    { 25, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "ali.engineer@example.com", true, false, null, "علي يوسف", "ALI.ENGINEER@EXAMPLE.COM", "ALI.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "0334455667", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "ali.engineer" },
                    { 26, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "fatima.engineer@example.com", true, false, null, "فاطمة سعيد", "FATIMA.ENGINEER@EXAMPLE.COM", "FATIMA.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "0445566778", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "fatima.engineer" },
                    { 27, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "khaled.engineer@example.com", true, false, null, "خالد عبد الله", "KHALED.ENGINEER@EXAMPLE.COM", "KHALED.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "0556677889", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "khaled.engineer" },
                    { 28, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "mariam.engineer@example.com", true, false, null, "مريم أحمد", "MARIAM.ENGINEER@EXAMPLE.COM", "MARIAM.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "0667788990", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "mariam.engineer" },
                    { 29, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "youssef.engineer@example.com", true, false, null, "يوسف علي", "YOUSSEF.ENGINEER@EXAMPLE.COM", "YOUSSEF.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "0778899001", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "youssef.engineer" },
                    { 30, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "nora.engineer@example.com", true, false, null, "نورا محمد", "NORA.ENGINEER@EXAMPLE.COM", "NORA.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "0889900112", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "nora.engineer" },
                    { 31, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "hassan.engineer@example.com", true, false, null, "حسن علي", "HASSAN.ENGINEER@EXAMPLE.COM", "HASSAN.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "0990011223", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "hassan.engineer" },
                    { 32, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "mona.engineer@example.com", true, false, null, "منى سعيد", "MONA.ENGINEER@EXAMPLE.COM", "MONA.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "0106622334", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "mona.engineer" },
                    { 33, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "omar.engineer@example.com", true, false, null, "عمر خالد", "OMAR.ENGINEER@EXAMPLE.COM", "OMAR.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "00025533445", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "omar.engineer" },
                    { 34, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "huda.engineer@example.com", true, false, null, "هدى إبراهيم", "HUDA.ENGINEER@EXAMPLE.COM", "HUDA.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "01113446656", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "huda.engineer" },
                    { 35, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "yasser.engineer@example.com", true, false, null, "ياسر يوسف", "YASSER.ENGINEER@EXAMPLE.COM", "YASSER.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "0222005667", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "yasser.engineer" },
                    { 36, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "nadia.engineer@example.com", true, false, null, "نادية سعيد", "NADIA.ENGINEER@EXAMPLE.COM", "NADIA.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "4445555778", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "nadia.engineer" },
                    { 37, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "majed.engineer@example.com", true, false, null, "ماجد عبد الله", "MAJED.ENGINEER@EXAMPLE.COM", "MAJED.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "0566677889", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "majed.engineer" },
                    { 38, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "salma.engineer@example.com", true, false, null, "سلمى أحمد", "SALMA.ENGINEER@EXAMPLE.COM", "SALMA.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "0688898990", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "salma.engineer" },
                    { 39, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "ziad.engineer@example.com", true, false, null, "زياد علي", "ZIAD.ENGINEER@EXAMPLE.COM", "ZIAD.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "01118800001", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "ziad.engineer" },
                    { 40, 0, 1, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", "noor.engineer@example.com", true, false, null, "نور محمد", "NOOR.ENGINEER@EXAMPLE.COM", "NOOR.ENGINEER", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "06900112", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "noor.engineer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_BelongToUserId",
                table: "Users",
                column: "BelongToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_SiteEngineerId",
                table: "Projects",
                column: "SiteEngineerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_BelongToUserId",
                table: "Users",
                column: "BelongToUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_SiteEngineerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_BelongToUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BelongToUserId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DropColumn(
                name: "BelongToUserId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "SiteEngineers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteEngineers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteEngineers_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiteEngineers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "FirstName", "IsDeleted", "LastName", "ModifiedDate", "NationalNumber", "PhoneNumber", "SecondName", "ThirdName" },
                values: new object[,]
                {
                    { 21, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ahmed.engineer@example.com", "أحمد", false, "محمد", null, null, "01553456789", null, null },
                    { 22, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sara.engineer@example.com", "سارة", false, "علي", null, null, "0987654321", null, null },
                    { 23, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mohamed.engineer@example.com", "محمد", false, "حسن", null, null, "0112233445", null, null },
                    { 24, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "leila.engineer@example.com", "ليلى", false, "إبراهيم", null, null, "0223344556", null, null },
                    { 25, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ali.engineer@example.com", "علي", false, "يوسف", null, null, "0334455667", null, null },
                    { 26, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fatima.engineer@example.com", "فاطمة", false, "سعيد", null, null, "0445566778", null, null },
                    { 27, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "khaled.engineer@example.com", "خالد", false, "عبد الله", null, null, "0556677889", null, null },
                    { 28, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mariam.engineer@example.com", "مريم", false, "أحمد", null, null, "0667788990", null, null },
                    { 29, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "youssef.engineer@example.com", "يوسف", false, "علي", null, null, "0778899001", null, null },
                    { 30, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nora.engineer@example.com", "نورا", false, "محمد", null, null, "0889900112", null, null },
                    { 31, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "hassan.engineer@example.com", "حسن", false, "علي", null, null, "0990011223", null, null },
                    { 32, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mona.engineer@example.com", "منى", false, "سعيد", null, null, "0106622334", null, null },
                    { 33, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "omar.engineer@example.com", "عمر", false, "خالد", null, null, "00025533445", null, null },
                    { 34, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "huda.engineer@example.com", "هدى", false, "إبراهيم", null, null, "01113446656", null, null },
                    { 35, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "yasser.engineer@example.com", "ياسر", false, "يوسف", null, null, "0222005667", null, null },
                    { 36, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nadia.engineer@example.com", "نادية", false, "سعيد", null, null, "4445555778", null, null },
                    { 37, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "majed.engineer@example.com", "ماجد", false, "عبد الله", null, null, "0566677889", null, null },
                    { 38, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "salma.engineer@example.com", "سلمى", false, "أحمد", null, null, "0688898990", null, null },
                    { 39, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ziad.engineer@example.com", "زياد", false, "علي", null, null, "01118800001", null, null },
                    { 40, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "noor.engineer@example.com", "نور", false, "محمد", null, null, "06900112", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "SiteEngineerId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "SiteEngineerId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "SiteEngineerId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                column: "SiteEngineerId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5,
                column: "SiteEngineerId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6,
                column: "SiteEngineerId",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 7,
                column: "SiteEngineerId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 8,
                column: "SiteEngineerId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 9,
                column: "SiteEngineerId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 10,
                column: "SiteEngineerId",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 11,
                column: "SiteEngineerId",
                value: 31);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 12,
                column: "SiteEngineerId",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 13,
                column: "SiteEngineerId",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 14,
                column: "SiteEngineerId",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 15,
                column: "SiteEngineerId",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 16,
                column: "SiteEngineerId",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 17,
                column: "SiteEngineerId",
                value: 37);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 18,
                column: "SiteEngineerId",
                value: 38);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 19,
                column: "SiteEngineerId",
                value: 39);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 20,
                column: "SiteEngineerId",
                value: 40);

            migrationBuilder.InsertData(
                table: "SiteEngineers",
                columns: new[] { "Id", "HireDate", "Password", "UserId" },
                values: new object[,]
                {
                    { 21, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 22, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 23, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 24, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 25, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 26, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 27, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 28, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 29, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 30, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 31, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 32, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 33, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 34, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 35, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 36, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 37, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 38, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 39, new DateOnly(2019, 8, 1), "12345678", 1 },
                    { 40, new DateOnly(2019, 8, 1), "12345678", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiteEngineers_UserId",
                table: "SiteEngineers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_SiteEngineers_SiteEngineerId",
                table: "Projects",
                column: "SiteEngineerId",
                principalTable: "SiteEngineers",
                principalColumn: "Id");
        }
    }
}
