using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConstructionManagementAssistant_EF.Migrations
{
    /// <inheritdoc />
    public partial class SeedSiteEngineers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhoneNumber",
                value: "0344455667");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "PhoneNumber",
                value: "14490011223");

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "FirstName", "IsDeleted", "LastName", "ModifiedDate", "NationalNumber", "PhoneNumber", "SecondName", "ThirdName" },
                values: new object[,]
                {
                    { 21, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ahmed.engineer@example.com", "أحمد", false, "محمد", null, null, "01123456789", null, null },
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

            migrationBuilder.InsertData(
                table: "SiteEngineers",
                columns: new[] { "Id", "HireDate", "IsAvailable" },
                values: new object[,]
                {
                    { 21, new DateOnly(2019, 8, 1), true },
                    { 22, new DateOnly(2019, 8, 1), true },
                    { 23, new DateOnly(2019, 8, 1), true },
                    { 24, new DateOnly(2019, 8, 1), true },
                    { 25, new DateOnly(2019, 8, 1), true },
                    { 26, new DateOnly(2019, 8, 1), true },
                    { 27, new DateOnly(2019, 8, 1), true },
                    { 28, new DateOnly(2019, 8, 1), true },
                    { 29, new DateOnly(2019, 8, 1), true },
                    { 30, new DateOnly(2019, 8, 1), true },
                    { 31, new DateOnly(2019, 8, 1), true },
                    { 32, new DateOnly(2019, 8, 1), true },
                    { 33, new DateOnly(2019, 8, 1), true },
                    { 34, new DateOnly(2019, 8, 1), true },
                    { 35, new DateOnly(2019, 8, 1), true },
                    { 36, new DateOnly(2019, 8, 1), true },
                    { 37, new DateOnly(2019, 8, 1), true },
                    { 38, new DateOnly(2019, 8, 1), true },
                    { 39, new DateOnly(2019, 8, 1), true },
                    { 40, new DateOnly(2019, 8, 1), true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "SiteEngineers",
                keyColumn: "Id",
                keyValue: 40);

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

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhoneNumber",
                value: "0334455667");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "PhoneNumber",
                value: "10990011223");
        }
    }
}
