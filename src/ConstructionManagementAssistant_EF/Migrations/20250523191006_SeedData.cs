using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConstructionManagementAssistant.EF.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "FirstName", "IsDeleted", "LastName", "ModifiedDate", "NationalNumber", "PhoneNumber", "SecondName", "ThirdName" },
                values: new object[,]
                {
                    { 1, "شارع 10, الرياض", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mohamedd@example.com", "محمد", false, "الخالد", null, "123456789", "0512345611", "علي", "حسن" },
                    { 2, "شارع 20, جدة", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ahmedd@example.com", "أحمد", false, "الفهيد", null, "227654321", "0228765432", "خالد", "سعيد" },
                    { 3, "شارع 30, مكة", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aliee@example.com", "علي", false, "الغامدي", null, "446789123", "0445678912", "ياسر", "طارق" },
                    { 4, "شارع 40, المدينة", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "khassled@example.com", "خالد", false, "السعيد", null, "1131654987", "0555165498", "عمر", "مصطفى" },
                    { 5, "شارع 50, الدمام", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "yas4ser@example.com", "ياسر", false, "النجار", null, "654667321", "0565498732", "حسن", "سعد" },
                    { 6, "شارع 60, الخبر", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "taridq@example.com", "طارق", false, "الزيد", null, "782223456", "668912345", "سعيد", "محمد" },
                    { 7, "شارع 70, الطائف", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mustaffa@example.com", "مصطفى", false, "العبيد", null, "852963741", "0585296374", "عبدالله", "أحمد" },
                    { 8, "شارع 80, تبوك", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "saeefd@example.com", "سعيد", false, "الرشيد", null, "963852741", "0596385274", "علي", "خالد" },
                    { 9, "شارع 90, بريدة", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "omar@examp2le.com", "عمر", false, "الغامدي", null, "7431852963", "05743185296", "ياسر", "طارق" },
                    { 10, "شارع 100, حائل", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "hass2an@example.com", "حسن", false, "الفهيد", null, "3692528147", "05369225814", "محمد", "أحمد" },
                    { 11, "شارع 110, الرياض", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fahad@exam2ple.com", "فهد", false, "العبيد", null, "1592357486", "05125935748", "عبدالرحمن", "ناصر" },
                    { 12, "شارع 120, جدة", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nasse2r@example.com", "ناصر", false, "الزيد", null, "7523159486", "05275315948", "سلمان", "فيصل" },
                    { 13, "شارع 130, مكة", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "faidsal@example.com", "فيصل", false, "الرشيد", null, "4862753159", "05483675315", "عبدالعزيز", "راشد" },
                    { 14, "شارع 140, المدينة", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "rashed@example.com", "راشد", false, "السعد", null, "35337159486", "02535715948", "عبدالله", "سعد" },
                    { 15, "شارع 150, الدمام", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "saad@example.com", "سعد", false, "الفهد", null, "95321753486", "05295175348", "عبدالمحسن", "فهد" },
                    { 16, "شارع 160, الخبر", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "abdullah@example.com", "عبدالله", false, "الناصر", null, "753486159", "0575348615", "عبدالرحمن", "ناصر" },
                    { 17, "شارع 170, الطائف", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "abdulrahman@example.com", "عبدالرحمن", false, "الراشد", null, "486159753", "0548615975", "فيصل", "راشد" },
                    { 18, "شارع 180, تبوك", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "abdulaziz@example.com", "عبدالعزيز", false, "الفهد", null, "159486753", "0515948675", "سعد", "فهد" },
                    { 19, "شارع 190, بريدة", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "salman@example.com", "سلمان", false, "العبدالله", null, "753159486", "0575315948", "راشد", "عبدالله" },
                    { 20, "شارع 200, حائل", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "abdulmohsen@example.com", "عبدالمحسن", false, "الناصر", null, "486753159", "0548675315", "فهد", "ناصر" },
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "b1e1a1c2-1111-4444-aaaa-000000000001", "Admin", "ADMIN" },
                    { 2, "b1e1a1c2-2222-4444-bbbb-000000000002", "SiteEngineer", "SITEENGINEER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "446eab07-ad33-4b55-9268-2d4e60fb6b62", "salhbnsmyd3@gmail.com", true, false, null, "saleh mohammed", "SALHBNSMYD3@GMAIL.COM", "SALHBNSMYD3", "AQAAAAIAAYagAAAAEEhXAUHV7cc6ecl49uJ+WcKtnbGjqbMYZMLcIvumr2D30zXfRoHSyIXUv+EzZBfR8g==", "777753928", true, "SOKZD3Q27H66B63UEVAFQDGKZBDGOBUX", false, "salhbnsmyd3" });

            migrationBuilder.InsertData(
                table: "WorkerSpecialties",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "نجار" },
                    { 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "حداد" },
                    { 3, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "سباك" },
                    { 4, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "كهربائي" },
                    { 5, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء" },
                    { 6, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "دهان" },
                    { 7, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "مبلط" },
                    { 8, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "مقاول" },
                    { 9, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "مهندس معماري" },
                    { 10, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "مهندس مدني" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ClientType", "CreatedDate", "DeletedDate", "Email", "FullName", "IsDeleted", "ModifiedDate", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ahmed@example.com", "أحمد محمد", false, null, "1121456789", 1 },
                    { 2, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sara@example.com", "سارة علي", false, null, "2927654321", 1 },
                    { 3, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mohamed@example.com", "محمد حسن", false, null, "31128833445", 1 },
                    { 4, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "leila@example.com", "ليلى إبراهيم", false, null, "4243344556", 1 },
                    { 5, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ali@example.com", "علي يوسف", false, null, "0344455667", 1 },
                    { 6, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fatima@example.com", "فاطمة سعيد", false, null, "5445566778", 1 },
                    { 7, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "khaled@example.com", "خالد عبد الله", false, null, "6556677889", 1 },
                    { 8, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mariam@example.com", "مريم أحمد", false, null, "7667788990", 1 },
                    { 9, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "youssef@example.com", "يوسف علي", false, null, "0878899001", 1 },
                    { 10, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nora@example.com", "نورا محمد", false, null, "9889900112", 1 },
                    { 11, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "hassan@example.com", "حسن علي", false, null, "14490011223", 1 },
                    { 12, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mona@example.com", "منى سعيد", false, null, "01022122334", 1 },
                    { 13, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "omar@example.com", "عمر خالد", false, null, "01112233445", 1 },
                    { 14, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "huda@example.com", "هدى إبراهيم", false, null, "2223344556", 1 },
                    { 15, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "yasser@example.com", "ياسر يوسف", false, null, "03744455667", 1 },
                    { 16, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nadia@example.com", "نادية سعيد", false, null, "0045566778", 1 },
                    { 17, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "majed@example.com", "ماجد عبد الله", false, null, "9956677889", 1 },
                    { 18, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "salma@example.com", "سلمى أحمد", false, null, "0667788990", 1 },
                    { 19, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ziad@example.com", "زياد علي", false, null, "0228899001", 1 },
                    { 20, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "noor@example.com", "نور محمد", false, null, "0874900112", 1 }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "CreatedDate", "Model", "ModifiedDate", "Name", "Notes", "PurchaseDate", "SerialNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAT 320D", null, "Excavator", "Heavy duty excavator for ground work", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "EXC-2023-001", 1 },
                    { 2, new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Komatsu D65PX-18", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bulldozer", "Currently at downtown construction site", new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "BUL-2022-045", 1 },
                    { 3, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Volvo L120H", null, "Wheel Loader", "New addition to fleet", new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "WL-2023-008", 1 },
                    { 4, new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "JCB 3CX", new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Backhoe Loader", "Hydraulic leak detected", new DateTime(2021, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BHL-2021-112", 1 },
                    { 5, new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bobcat S650", null, "Skid Steer Loader", "With pallet forks attachment", new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "SSL-2022-078", 1 },
                    { 6, new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAT 120K", new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Motor Grader", "Road construction project", new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GRD-2020-034", 1 },
                    { 7, new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Volvo A30G", null, "Articulated Dump Truck", "30-ton capacity", new DateTime(2021, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADT-2021-056", 1 },
                    { 8, new DateTime(2019, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAT D6T", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crawler Dozer", "Pending major engine overhaul", new DateTime(2019, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CDZ-2019-023", 1 },
                    { 9, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "JCB 536-70", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Telescopic Handler", "High reach capability", new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "TH-2022-091", 1 },
                    { 10, new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ICE 1412", null, "Pile Driver", "Foundation work equipment", new DateTime(2020, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "PD-2020-017", 1 },
                    { 11, new DateTime(2021, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Putzmeister M42", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concrete Mixer Truck", "9 cubic meter capacity", new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CMT-2021-045", 1 },
                    { 12, new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schwing S36X", null, "Concrete Pump", "Boom pump 36 meters", new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "CP-2022-033", 1 },
                    { 13, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wacker Neuson AR36", null, "Concrete Vibrator", "Internal vibration system", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CV-2023-009", 1 },
                    { 14, new DateTime(2021, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Husqvarna K760", new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concrete Saw", "Blade replacement needed", new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "CS-2021-028", 1 },
                    { 15, new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allen Eng. SP-16", null, "Concrete Finisher", "16-foot finishing width", new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CF-2020-019", 1 },
                    { 16, new DateTime(2021, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liebherr 63EC", new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tower Crane", "High-rise construction project", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "TC-2021-007", 1 },
                    { 17, new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tadano ATF-220G-5", null, "Mobile Crane", "220-ton capacity", new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "MC-2022-014", 1 },
                    { 18, new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grove RT880E", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rough Terrain Crane", "Annual inspection", new DateTime(2020, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "RTC-2020-026", 1 },
                    { 19, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toyota 8FGCU25", new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forklift", "Warehouse operations", new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FL-2021-038", 1 },
                    { 20, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Genie GS-3246", null, "Scissor Lift", "32ft working height", new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "SL-2022-021", 1 },
                    { 21, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bomag BW211D-40", null, "Vibratory Roller", "For asphalt compaction work", new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "VR-2023-005", 1 },
                    { 22, new DateTime(2021, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wacker Neuson WP1550", new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plate Compactor", "Trench backfilling", new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "PC-2021-029", 1 },
                    { 23, new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vermeer RTX550", null, "Trencher", "Chain-type trencher", new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TR-2020-031", 1 },
                    { 24, new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Volvo ABG6820", new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asphalt Paver", "Screed calibration", new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "AP-2021-042", 1 },
                    { 25, new DateTime(2019, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wirtgen W2000", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cold Planer", "End of service life", new DateTime(2019, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "CP-2019-015", 1 },
                    { 26, new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cummins QSK60", new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generator", "Powering north site operations", new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GEN-2022-032", 1 },
                    { 27, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Atlas Copco XAS185", null, "Air Compressor", "185 cfm capacity", new DateTime(2021, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "AC-2021-027", 1 },
                    { 28, new DateTime(2022, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generac Light Tower", new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Light Tower", "Night shift operations", new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "LT-2022-019", 1 },
                    { 29, new DateTime(2020, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Godwin HL100", null, "Water Pump", "High volume dewatering", new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "WP-2020-024", 1 },
                    { 30, new DateTime(2021, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lincoln Vantage 400", new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welding Machine", "Electrode feeder repair", new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "WM-2021-036", 1 }
                });

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

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "SpecialtyId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 },
                    { 6, 6, 1 },
                    { 7, 7, 1 },
                    { 8, 8, 1 },
                    { 9, 9, 1 },
                    { 10, 10, 1 },
                    { 11, 1, 1 },
                    { 12, 2, 1 },
                    { 13, 3, 1 },
                    { 14, 4, 1 },
                    { 15, 5, 1 },
                    { 16, 6, 1 },
                    { 17, 7, 1 },
                    { 18, 8, 1 },
                    { 19, 9, 1 },
                    { 20, 10, 1 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CancelationDate", "CancelationReason", "ClientId", "CompletionDate", "CreatedDate", "DeletedDate", "Description", "ExpectedEndDate", "GeographicalCoordinates", "HandoverDate", "IsDeleted", "ModifiedDate", "Name", "SiteAddress", "SiteEngineerId", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, null, null, 1, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء مدرسة ابتدائية في المدينة", new DateOnly(2022, 12, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء مدرسة", "المدينة، شارع 1", 21, new DateOnly(2022, 10, 1), 0 },
                    { 2, null, null, 2, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء مستشفى عام في المدينة", new DateOnly(2022, 12, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء مستشفى", "المدينة، شارع 2", 22, new DateOnly(2022, 10, 1), 0 },
                    { 3, null, null, 3, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء مجمع سكني فاخر", new DateOnly(2020, 8, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء مجمع سكني", "المدينة، شارع 3", 23, new DateOnly(2022, 10, 1), 0 },
                    { 4, null, null, 4, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء جسر يربط بين منطقتين", new DateOnly(2020, 8, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء جسر", "المدينة، شارع 4", 24, new DateOnly(2022, 10, 1), 0 },
                    { 5, null, null, 5, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء مصنع لإنتاج المواد الغذائية", new DateOnly(2020, 8, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء مصنع", "المدينة، شارع 5", 25, new DateOnly(2022, 10, 1), 0 },
                    { 6, null, null, 6, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء فندق خمس نجوم", new DateOnly(2020, 8, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء فندق", "المدينة، شارع 6", 26, new DateOnly(2022, 10, 1), 0 },
                    { 7, null, null, 7, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء محطة قطار حديثة", new DateOnly(2020, 8, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء محطة قطار", "المدينة، شارع 7", 27, new DateOnly(2022, 10, 1), 0 },
                    { 8, null, null, 8, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء مركز تجاري ضخم", new DateOnly(2020, 8, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء مركز تجاري", "المدينة، شارع 8", 28, new DateOnly(2022, 10, 1), 0 },
                    { 9, null, null, 9, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء جامعة حديثة", new DateOnly(2020, 8, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء جامعة", "المدينة، شارع 9", 29, new DateOnly(2022, 10, 1), 0 },
                    { 10, null, null, 10, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء حديقة عامة كبيرة", new DateOnly(2020, 8, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء حديقة عامة", "المدينة، شارع 10", 30, new DateOnly(2022, 10, 1), 0 },
                    { 11, null, null, 11, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء مكتبة عامة في المدينة", new DateOnly(2022, 12, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء مكتبة عامة", "المدينة، شارع 11", 31, new DateOnly(2022, 10, 1), 0 },
                    { 12, null, null, 12, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء ملعب رياضي حديث", new DateOnly(2022, 12, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء ملعب رياضي", "المدينة، شارع 12", 32, new DateOnly(2022, 10, 1), 0 },
                    { 13, null, null, 13, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء محطة وقود حديثة", new DateOnly(2022, 11, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء محطة وقود", "المدينة، شارع 13", 33, new DateOnly(2022, 10, 1), 0 },
                    { 14, null, null, 14, new DateOnly(2020, 9, 1), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء مركز صحي في المدينة", new DateOnly(2020, 8, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء مركز صحي", "المدينة، شارع 14", 34, new DateOnly(2022, 10, 1), 2 },
                    { 15, null, null, 15, new DateOnly(2020, 9, 1), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء مجمع تجاري ضخم", new DateOnly(2020, 8, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء مجمع تجاري", "المدينة، شارع 15", 35, new DateOnly(2022, 10, 1), 2 },
                    { 16, null, null, 16, new DateOnly(2020, 9, 1), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء محطة كهرباء حديثة", new DateOnly(2020, 8, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء محطة كهرباء", "المدينة، شارع 16", 36, new DateOnly(2022, 10, 1), 2 },
                    { 17, null, null, 17, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء محطة مياه حديثة", new DateOnly(2020, 8, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء محطة مياه", "المدينة، شارع 17", 37, new DateOnly(2022, 10, 1), 1 },
                    { 18, null, null, 18, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء مركز شرطة حديث", new DateOnly(2020, 8, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء مركز شرطة", "المدينة، شارع 18", 38, new DateOnly(2022, 10, 1), 1 },
                    { 19, new DateOnly(2020, 9, 1), "تم إلغاء المشروع بسبب نقص التمويل", 19, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء محطة إطفاء حديثة", new DateOnly(2020, 8, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء محطة إطفاء", "المدينة، شارع 19", 39, new DateOnly(2022, 10, 1), 3 },
                    { 20, new DateOnly(2020, 9, 1), "تم إلغاء المشروع بسبب تغير الأولويات", 20, null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "بناء مركز ثقافي حديث", new DateOnly(2020, 8, 1), "24.7136, 46.6753", null, false, null, "مشروع بناء مركز ثقافي", "المدينة، شارع 20", 40, new DateOnly(2022, 10, 1), 3 }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "CreatedDate", "Description", "ExpectedEndDate", "ModifiedDate", "Name", "ProjectId", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة تصميم المدرسة", new DateOnly(2022, 11, 1), null, "تصميم", 1, new DateOnly(2022, 11, 1) },
                    { 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء المدرسة", new DateOnly(2022, 11, 1), null, "بناء", 1, new DateOnly(2022, 11, 1) },
                    { 3, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التشطيب النهائية", new DateOnly(2022, 11, 1), null, "تشطيب", 1, new DateOnly(2022, 11, 1) },
                    { 4, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة تصميم المستشفى", new DateOnly(2022, 11, 1), null, "تصميم", 2, new DateOnly(2022, 11, 1) },
                    { 5, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء المستشفى", new DateOnly(2022, 11, 1), null, "بناء", 2, new DateOnly(2022, 11, 1) },
                    { 6, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التشطيب النهائية", new DateOnly(2022, 11, 1), null, "تشطيب", 2, new DateOnly(2022, 11, 1) },
                    { 7, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة تصميم المجمع السكني", new DateOnly(2022, 11, 1), null, "تصميم", 3, new DateOnly(2022, 11, 1) },
                    { 8, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء المجمع السكني", new DateOnly(2022, 11, 1), null, "بناء", 3, new DateOnly(2022, 11, 1) },
                    { 9, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التشطيب النهائية", new DateOnly(2022, 11, 1), null, "تشطيب", 3, new DateOnly(2022, 11, 1) },
                    { 10, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة تصميم الجسر", new DateOnly(2022, 11, 1), null, "تصميم", 4, new DateOnly(2022, 11, 1) },
                    { 11, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء الجسر", new DateOnly(2022, 11, 1), null, "بناء", 4, new DateOnly(2022, 11, 1) },
                    { 12, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التشطيب النهائية", new DateOnly(2022, 11, 1), null, "تشطيب", 4, new DateOnly(2022, 11, 1) },
                    { 13, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة تصميم المصنع", new DateOnly(2022, 11, 1), null, "تصميم", 5, new DateOnly(2022, 11, 1) },
                    { 14, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء المصنع", new DateOnly(2022, 11, 1), null, "بناء", 5, new DateOnly(2022, 11, 1) },
                    { 15, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التشطيب النهائية", new DateOnly(2022, 11, 1), null, "تشطيب", 5, new DateOnly(2022, 11, 1) },
                    { 16, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة تصميم الفندق", new DateOnly(2022, 11, 1), null, "تصميم", 6, new DateOnly(2022, 11, 1) },
                    { 17, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء الفندق", new DateOnly(2022, 11, 1), null, "بناء", 6, new DateOnly(2022, 11, 1) },
                    { 18, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التشطيب النهائية", new DateOnly(2022, 11, 1), null, "تشطيب", 6, new DateOnly(2022, 11, 1) },
                    { 19, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة تصميم محطة القطار", new DateOnly(2022, 11, 1), null, "تصميم", 7, new DateOnly(2022, 11, 1) },
                    { 20, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء محطة القطار", new DateOnly(2022, 11, 1), null, "بناء", 7, new DateOnly(2022, 11, 1) },
                    { 21, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التشطيب النهائية", new DateOnly(2022, 11, 1), null, "تشطيب", 7, new DateOnly(2022, 11, 1) },
                    { 22, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة تصميم المركز التجاري", new DateOnly(2022, 11, 1), null, "تصميم", 8, new DateOnly(2022, 11, 1) },
                    { 23, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء المركز التجاري", new DateOnly(2022, 11, 1), null, "بناء", 8, new DateOnly(2022, 11, 1) },
                    { 24, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التشطيب النهائية", new DateOnly(2022, 11, 1), null, "تشطيب", 8, new DateOnly(2022, 11, 1) },
                    { 25, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة تصميم الجامعة", new DateOnly(2022, 11, 1), null, "تصميم", 9, new DateOnly(2022, 11, 1) },
                    { 26, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء الجامعة", new DateOnly(2022, 11, 1), null, "بناء", 9, new DateOnly(2022, 11, 1) },
                    { 27, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التشطيب النهائية", new DateOnly(2022, 11, 1), null, "تشطيب", 9, new DateOnly(2022, 11, 1) },
                    { 28, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة تصميم الحديقة العامة", new DateOnly(2022, 11, 1), null, "تصميم", 10, new DateOnly(2022, 11, 1) },
                    { 29, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء الحديقة العامة", new DateOnly(2022, 11, 1), null, "بناء", 10, new DateOnly(2022, 11, 1) },
                    { 30, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التشطيب النهائية", new DateOnly(2022, 11, 1), null, "تشطيب", 10, new DateOnly(2022, 11, 1) },
                    { 31, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التخطيط للمكتبة العامة", new DateOnly(2022, 11, 1), null, "التخطيط", 11, new DateOnly(2022, 11, 1) },
                    { 32, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء المكتبة العامة", new DateOnly(2022, 11, 1), null, "التنفيذ", 11, new DateOnly(2022, 11, 1) },
                    { 33, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "الفحص النهائي للمكتبة قبل الافتتاح", new DateOnly(2022, 11, 1), null, "الفحص النهائي", 11, new DateOnly(2022, 11, 1) },
                    { 34, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التخطيط للملعب الرياضي", new DateOnly(2022, 11, 1), null, "التخطيط", 12, new DateOnly(2022, 11, 1) },
                    { 35, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء الملعب الرياضي", new DateOnly(2022, 11, 1), null, "التنفيذ", 12, new DateOnly(2022, 11, 1) },
                    { 36, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "الفحص النهائي للملعب الرياضي", new DateOnly(2022, 11, 1), null, "الفحص النهائي", 12, new DateOnly(2022, 11, 1) },
                    { 37, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التخطيط لمحطة الوقود", new DateOnly(2022, 11, 1), null, "التخطيط", 13, new DateOnly(2022, 11, 1) },
                    { 38, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء محطة الوقود", new DateOnly(2022, 11, 1), null, "التنفيذ", 13, new DateOnly(2022, 11, 1) },
                    { 39, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "الفحص النهائي لمحطة الوقود", new DateOnly(2022, 11, 1), null, "الفحص النهائي", 13, new DateOnly(2022, 11, 1) },
                    { 40, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التخطيط للمركز الصحي", new DateOnly(2022, 11, 1), null, "التخطيط", 14, new DateOnly(2022, 11, 1) },
                    { 41, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء المركز الصحي", new DateOnly(2022, 11, 1), null, "التنفيذ", 14, new DateOnly(2022, 11, 1) },
                    { 42, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "الفحص النهائي للمركز الصحي", new DateOnly(2022, 11, 1), null, "الفحص النهائي", 14, new DateOnly(2022, 11, 1) },
                    { 43, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التخطيط للمجمع التجاري", new DateOnly(2022, 11, 1), null, "التخطيط", 15, new DateOnly(2022, 11, 1) },
                    { 44, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء المجمع التجاري", new DateOnly(2022, 11, 1), null, "التنفيذ", 15, new DateOnly(2022, 11, 1) },
                    { 45, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "الفحص النهائي للمجمع التجاري", new DateOnly(2022, 11, 1), null, "الفحص النهائي", 15, new DateOnly(2022, 11, 1) },
                    { 46, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التخطيط لمحطة الكهرباء", new DateOnly(2022, 11, 1), null, "التخطيط", 16, new DateOnly(2022, 11, 1) },
                    { 47, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء محطة الكهرباء", new DateOnly(2022, 11, 1), null, "التنفيذ", 16, new DateOnly(2022, 11, 1) },
                    { 48, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "الفحص النهائي لمحطة الكهرباء", new DateOnly(2022, 11, 1), null, "الفحص النهائي", 16, new DateOnly(2022, 11, 1) },
                    { 49, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التخطيط لمحطة المياه", new DateOnly(2022, 11, 1), null, "التخطيط", 17, new DateOnly(2022, 11, 1) },
                    { 50, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء محطة المياه", new DateOnly(2022, 11, 1), null, "التنفيذ", 17, new DateOnly(2022, 11, 1) },
                    { 51, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "الفحص النهائي لمحطة المياه", new DateOnly(2022, 11, 1), null, "الفحص النهائي", 17, new DateOnly(2022, 11, 1) },
                    { 52, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التخطيط لمركز الشرطة", new DateOnly(2022, 11, 1), null, "التخطيط", 18, new DateOnly(2022, 11, 1) },
                    { 53, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء مركز الشرطة", new DateOnly(2022, 11, 1), null, "التنفيذ", 18, new DateOnly(2022, 11, 1) },
                    { 54, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "الفحص النهائي لمركز الشرطة", new DateOnly(2022, 11, 1), null, "الفحص النهائي", 18, new DateOnly(2022, 11, 1) },
                    { 55, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التخطيط لمحطة الإطفاء", new DateOnly(2022, 11, 1), null, "التخطيط", 19, new DateOnly(2022, 11, 1) },
                    { 56, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء محطة الإطفاء", new DateOnly(2022, 11, 1), null, "التنفيذ", 19, new DateOnly(2022, 11, 1) },
                    { 57, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "الفحص النهائي لمحطة الإطفاء", new DateOnly(2022, 11, 1), null, "الفحص النهائي", 19, new DateOnly(2022, 11, 1) },
                    { 58, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة التخطيط للمركز الثقافي", new DateOnly(2022, 11, 1), null, "التخطيط", 20, new DateOnly(2022, 11, 1) },
                    { 59, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرحلة بناء المركز الثقافي", new DateOnly(2022, 11, 1), null, "التنفيذ", 20, new DateOnly(2022, 11, 1) },
                    { 60, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "الفحص النهائي للمركز الثقافي", new DateOnly(2022, 11, 1), null, "الفحص النهائي", 20, new DateOnly(2022, 11, 1) }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedDate", "Description", "ExpectedEndDate", "IsCompleted", "ModifiedDate", "Name", "StageId", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Collect requirements for the library design.", new DateOnly(2022, 11, 1), false, null, "Gather Requirements", 1, new DateOnly(2022, 11, 1) },
                    { 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare initial architectural drafts.", new DateOnly(2022, 11, 1), false, null, "Create Design Draft", 1, new DateOnly(2022, 11, 1) },
                    { 3, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review designs with stakeholders.", new DateOnly(2022, 11, 1), false, null, "Conduct Design Review", 1, new DateOnly(2022, 11, 1) },
                    { 4, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Secure necessary construction permits.", new DateOnly(2022, 11, 1), false, null, "Obtain Permits", 1, new DateOnly(2022, 11, 1) },
                    { 5, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare and finalize the project budget.", new DateOnly(2022, 11, 1), true, null, "Finalize Budget", 1, new DateOnly(2022, 11, 1) },
                    { 6, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a suitable contractor for construction.", new DateOnly(2022, 11, 1), false, null, "Select Contractor", 2, new DateOnly(2022, 11, 1) },
                    { 7, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the site for construction.", new DateOnly(2022, 11, 1), false, null, "Site Preparation", 2, new DateOnly(2022, 11, 1) },
                    { 8, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conduct foundation work for the library.", new DateOnly(2022, 11, 1), false, null, "Foundation Work", 2, new DateOnly(2022, 11, 1) },
                    { 9, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete structural framing of the building.", new DateOnly(2022, 11, 1), false, null, "Structural Framing", 2, new DateOnly(2022, 11, 1) },
                    { 10, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install roofing for the library.", new DateOnly(2022, 11, 1), true, null, "Roof Installation", 2, new DateOnly(2022, 11, 1) },
                    { 11, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform general inspections of the construction.", new DateOnly(2022, 11, 1), false, null, "Conduct Inspections", 3, new DateOnly(2022, 11, 1) },
                    { 12, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems and wiring.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 3, new DateOnly(2022, 11, 1) },
                    { 13, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install heating, ventilation, and air conditioning systems.", new DateOnly(2022, 11, 1), false, null, "Install HVAC Systems", 3, new DateOnly(2022, 11, 1) },
                    { 14, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete final touch-ups and finishes.", new DateOnly(2022, 11, 1), false, null, "Final Touch-ups", 3, new DateOnly(2022, 11, 1) },
                    { 15, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the library for the opening ceremony.", new DateOnly(2022, 11, 1), true, null, "Prepare for Opening", 3, new DateOnly(2022, 11, 1) },
                    { 16, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analyze the site for the hospital.", new DateOnly(2022, 11, 1), false, null, "Conduct Site Analysis", 4, new DateOnly(2022, 11, 1) },
                    { 17, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare initial plans for the hospital.", new DateOnly(2022, 11, 1), false, null, "Develop Initial Plans", 4, new DateOnly(2022, 11, 1) },
                    { 18, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review plans with stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review with Stakeholders", 4, new DateOnly(2022, 11, 1) },
                    { 19, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Get necessary permits for construction.", new DateOnly(2022, 11, 1), false, null, "Obtain Construction Permits", 4, new DateOnly(2022, 11, 1) },
                    { 20, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Establish the project budget.", new DateOnly(2022, 11, 1), true, null, "Set Budget", 4, new DateOnly(2022, 11, 1) },
                    { 21, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Select a construction team for the hospital.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 5, new DateOnly(2022, 11, 1) },
                    { 22, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start the foundation work.", new DateOnly(2022, 11, 1), false, null, "Commence Foundation Work", 5, new DateOnly(2022, 11, 1) },
                    { 23, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Construct structural components of the hospital.", new DateOnly(2022, 11, 1), false, null, "Build Structural Components", 5, new DateOnly(2022, 11, 1) },
                    { 24, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install the roof structure.", new DateOnly(2022, 11, 1), false, null, "Install Roof", 5, new DateOnly(2022, 11, 1) },
                    { 25, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start internal work such as plumbing and electrical systems.", new DateOnly(2022, 11, 1), true, null, "Begin Internal Work", 5, new DateOnly(2022, 11, 1) },
                    { 26, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform a thorough final inspection.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 6, new DateOnly(2022, 11, 1) },
                    { 27, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete all internal installations.", new DateOnly(2022, 11, 1), false, null, "Finalize Internal Installations", 6, new DateOnly(2022, 11, 1) },
                    { 28, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the hospital for handover.", new DateOnly(2022, 11, 1), false, null, "Prepare for Hand Over", 6, new DateOnly(2022, 11, 1) },
                    { 29, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plan and organize the opening ceremony.", new DateOnly(2022, 11, 1), false, null, "Organize Opening Ceremony", 6, new DateOnly(2022, 11, 1) },
                    { 30, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conduct a project completion evaluation.", new DateOnly(2022, 11, 1), true, null, "Evaluate Project Completion", 6, new DateOnly(2022, 11, 1) },
                    { 31, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assess the site for residential complex.", new DateOnly(2022, 11, 1), false, null, "Conduct Site Assessment", 7, new DateOnly(2022, 11, 1) },
                    { 32, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create initial designs for the complex.", new DateOnly(2022, 11, 1), false, null, "Draft Initial Designs", 7, new DateOnly(2022, 11, 1) },
                    { 33, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review designs with stakeholders.", new DateOnly(2022, 11, 1), false, null, "Stakeholder Design Review", 7, new DateOnly(2022, 11, 1) },
                    { 34, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obtain necessary building permits.", new DateOnly(2022, 11, 1), false, null, "Get Necessary Permits", 7, new DateOnly(2022, 11, 1) },
                    { 35, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the project.", new DateOnly(2022, 11, 1), true, null, "Finalize Project Budget", 7, new DateOnly(2022, 11, 1) },
                    { 36, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the residential complex.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 8, new DateOnly(2022, 11, 1) },
                    { 37, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the site for construction activities.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 8, new DateOnly(2022, 11, 1) },
                    { 38, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start foundation work for the complex.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 8, new DateOnly(2022, 11, 1) },
                    { 39, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Build structural elements of the residential complex.", new DateOnly(2022, 11, 1), false, null, "Construct Structural Elements", 8, new DateOnly(2022, 11, 1) },
                    { 40, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install the roof structure for the complex.", new DateOnly(2022, 11, 1), false, null, "Install Roof Structure", 8, new DateOnly(2022, 11, 1) },
                    { 41, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the residential complex.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 9, new DateOnly(2022, 11, 1) },
                    { 42, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the complex.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 9, new DateOnly(2022, 11, 1) },
                    { 43, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install plumbing systems in the complex.", new DateOnly(2022, 11, 1), false, null, "Install Plumbing Systems", 9, new DateOnly(2022, 11, 1) },
                    { 44, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finish the interiors of the residential units.", new DateOnly(2022, 11, 1), false, null, "Complete Interior Finishes", 9, new DateOnly(2022, 11, 1) },
                    { 45, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the complex for handover to the client.", new DateOnly(2022, 11, 1), false, null, "Prepare for Handover", 9, new DateOnly(2022, 11, 1) },
                    { 46, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evaluate site conditions for bridge construction.", new DateOnly(2022, 11, 1), false, null, "Site Evaluation", 10, new DateOnly(2022, 11, 1) },
                    { 47, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create detailed design of the bridge.", new DateOnly(2022, 11, 1), false, null, "Prepare Detailed Design", 10, new DateOnly(2022, 11, 1) },
                    { 48, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review design with stakeholders.", new DateOnly(2022, 11, 1), false, null, "Conduct Design Review", 10, new DateOnly(2022, 11, 1) },
                    { 49, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire necessary construction permits.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 10, new DateOnly(2022, 11, 1) },
                    { 50, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize budget for the bridge construction.", new DateOnly(2022, 11, 1), false, null, "Finalize Project Budget", 10, new DateOnly(2022, 11, 1) },
                    { 51, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the bridge.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 11, new DateOnly(2022, 11, 1) },
                    { 52, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the site for bridge construction.", new DateOnly(2022, 11, 1), false, null, "Site Preparation", 11, new DateOnly(2022, 11, 1) },
                    { 53, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Begin foundation work for the bridge.", new DateOnly(2022, 11, 1), false, null, "Start Foundation Work", 11, new DateOnly(2022, 11, 1) },
                    { 54, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Construct the main structure of the bridge.", new DateOnly(2022, 11, 1), false, null, "Construct Bridge Structure", 11, new DateOnly(2022, 11, 1) },
                    { 55, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install safety features and barriers on the bridge.", new DateOnly(2022, 11, 1), false, null, "Install Safety Features", 11, new DateOnly(2022, 11, 1) },
                    { 56, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conduct final inspections of the bridge.", new DateOnly(2022, 11, 1), false, null, "Final Inspection", 12, new DateOnly(2022, 11, 1) },
                    { 57, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform load testing on the bridge.", new DateOnly(2022, 11, 1), false, null, "Conduct Load Testing", 12, new DateOnly(2022, 11, 1) },
                    { 58, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform load testing on the bridge.", new DateOnly(2022, 11, 1), false, null, "Conduct Load Testing", 12, new DateOnly(2022, 11, 1) },
                    { 59, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform load testing on the bridge.", new DateOnly(2022, 11, 1), false, null, "Conduct Load Testing", 12, new DateOnly(2022, 11, 1) },
                    { 60, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform load testing on the bridge.", new DateOnly(2022, 11, 1), false, null, "Conduct Load Testing", 12, new DateOnly(2022, 11, 1) },
                    { 61, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analyze site conditions for the factory.", new DateOnly(2022, 11, 1), false, null, "Conduct Site Analysis", 13, new DateOnly(2022, 11, 1) },
                    { 62, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare designs for the factory layout.", new DateOnly(2022, 11, 1), false, null, "Develop Initial Design", 13, new DateOnly(2022, 11, 1) },
                    { 63, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conduct a design review with stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review Design with Stakeholders", 13, new DateOnly(2022, 11, 1) },
                    { 64, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire permits for construction.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 13, new DateOnly(2022, 11, 1) },
                    { 65, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the factory project.", new DateOnly(2022, 11, 1), false, null, "Finalize Project Budget", 13, new DateOnly(2022, 11, 1) },
                    { 66, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the factory.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 14, new DateOnly(2022, 11, 1) },
                    { 67, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the site for factory construction.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 14, new DateOnly(2022, 11, 1) },
                    { 68, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start foundation work for the factory.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 14, new DateOnly(2022, 11, 1) },
                    { 69, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Build structural elements of the factory.", new DateOnly(2022, 11, 1), false, null, "Construct Structural Elements", 14, new DateOnly(2022, 11, 1) },
                    { 70, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install the roof structure for the factory.", new DateOnly(2022, 11, 1), false, null, "Install Roof Structure", 14, new DateOnly(2022, 11, 1) },
                    { 71, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform a final inspection of the factory.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 15, new DateOnly(2022, 11, 1) },
                    { 72, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the factory.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 15, new DateOnly(2022, 11, 1) },
                    { 73, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install HVAC systems in the factory.", new DateOnly(2022, 11, 1), false, null, "Install HVAC Systems", 15, new DateOnly(2022, 11, 1) },
                    { 74, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finish the interiors of the factory.", new DateOnly(2022, 11, 1), false, null, "Complete Interior Finishes", 15, new DateOnly(2022, 11, 1) },
                    { 75, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the factory for handover to the client.", new DateOnly(2022, 11, 1), false, null, "Prepare for Handover", 15, new DateOnly(2022, 11, 1) },
                    { 76, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Survey the site for the hotel construction.", new DateOnly(2022, 11, 1), false, null, "Perform Site Survey", 16, new DateOnly(2022, 11, 1) },
                    { 77, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create initial architectural designs for the hotel.", new DateOnly(2022, 11, 1), false, null, "Draft Initial Designs", 16, new DateOnly(2022, 11, 1) },
                    { 78, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conduct design review with stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review Design with Stakeholders", 16, new DateOnly(2022, 11, 1) },
                    { 79, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire necessary construction permits.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 16, new DateOnly(2022, 11, 1) },
                    { 80, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the hotel project.", new DateOnly(2022, 11, 1), false, null, "Finalize Project Budget", 16, new DateOnly(2022, 11, 1) },
                    { 81, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the hotel.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 17, new DateOnly(2022, 11, 1) },
                    { 82, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the site for hotel construction.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 17, new DateOnly(2022, 11, 1) },
                    { 83, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start foundation work for the hotel.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 17, new DateOnly(2022, 11, 1) },
                    { 84, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Construct structural components of the hotel.", new DateOnly(2022, 11, 1), false, null, "Construct Structural Components", 17, new DateOnly(2022, 11, 1) },
                    { 85, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install the roof structure for the hotel.", new DateOnly(2022, 11, 1), false, null, "Install Roof Structure", 17, new DateOnly(2022, 11, 1) },
                    { 86, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform a final inspection of the hotel.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 18, new DateOnly(2022, 11, 1) },
                    { 87, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the hotel.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 18, new DateOnly(2022, 11, 1) },
                    { 88, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install HVAC systems in the hotel.", new DateOnly(2022, 11, 1), false, null, "Install HVAC Systems", 18, new DateOnly(2022, 11, 1) },
                    { 89, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finish the interiors of the hotel.", new DateOnly(2022, 11, 1), false, null, "Complete Interior Finishes", 18, new DateOnly(2022, 11, 1) },
                    { 90, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the hotel for handover to the client.", new DateOnly(2022, 11, 1), false, null, "Prepare for Handover", 18, new DateOnly(2022, 11, 1) },
                    { 91, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assess site conditions for the train station.", new DateOnly(2022, 11, 1), false, null, "Conduct Site Assessment", 19, new DateOnly(2022, 11, 1) },
                    { 92, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare initial designs for the train station.", new DateOnly(2022, 11, 1), false, null, "Prepare Initial Designs", 19, new DateOnly(2022, 11, 1) },
                    { 93, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review plans with stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review with Stakeholders", 19, new DateOnly(2022, 11, 1) },
                    { 94, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire necessary construction permits.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 19, new DateOnly(2022, 11, 1) },
                    { 95, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the train station project.", new DateOnly(2022, 11, 1), false, null, "Finalize Project Budget", 19, new DateOnly(2022, 11, 1) },
                    { 96, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the train station.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 20, new DateOnly(2022, 11, 1) },
                    { 97, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the site for train station construction.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 20, new DateOnly(2022, 11, 1) },
                    { 98, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start foundation work for the train station.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 20, new DateOnly(2022, 11, 1) },
                    { 99, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Construct structural elements of the train station.", new DateOnly(2022, 11, 1), false, null, "Construct Structural Elements", 20, new DateOnly(2022, 11, 1) },
                    { 100, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install the roof structure for the train station.", new DateOnly(2022, 11, 1), false, null, "Install Roof Structure", 20, new DateOnly(2022, 11, 1) },
                    { 101, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the train station.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 21, new DateOnly(2022, 11, 1) },
                    { 102, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the train station.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 21, new DateOnly(2022, 11, 1) },
                    { 103, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install HVAC systems in the train station.", new DateOnly(2022, 11, 1), false, null, "Install HVAC Systems", 21, new DateOnly(2022, 11, 1) },
                    { 104, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finish the interiors of the train station.", new DateOnly(2022, 11, 1), false, null, "Complete Interior Finishes", 21, new DateOnly(2022, 11, 1) },
                    { 105, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the train station for handover to the client.", new DateOnly(2022, 11, 1), false, null, "Prepare for Handover", 21, new DateOnly(2022, 11, 1) },
                    { 106, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analyze the market for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Conduct Market Analysis", 22, new DateOnly(2022, 11, 1) },
                    { 107, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create initial layout designs for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Draft Initial Layout", 22, new DateOnly(2022, 11, 1) },
                    { 108, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review designs with stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review with Stakeholders", 22, new DateOnly(2022, 11, 1) },
                    { 109, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire necessary construction permits.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 22, new DateOnly(2022, 11, 1) },
                    { 110, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the shopping center project.", new DateOnly(2022, 11, 1), false, null, "Finalize Project Budget", 22, new DateOnly(2022, 11, 1) },
                    { 111, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 23, new DateOnly(2022, 11, 1) },
                    { 112, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the site for shopping center construction.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 23, new DateOnly(2022, 11, 1) },
                    { 113, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start foundation work for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 23, new DateOnly(2022, 11, 1) },
                    { 114, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Construct structural components of the shopping center.", new DateOnly(2022, 11, 1), false, null, "Construct Structural Components", 23, new DateOnly(2022, 11, 1) },
                    { 115, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install the roof structure for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Install Roof Structure", 23, new DateOnly(2022, 11, 1) },
                    { 116, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the shopping center.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 24, new DateOnly(2022, 11, 1) },
                    { 117, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 24, new DateOnly(2022, 11, 1) },
                    { 118, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 24, new DateOnly(2022, 11, 1) },
                    { 119, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 24, new DateOnly(2022, 11, 1) },
                    { 120, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 24, new DateOnly(2022, 11, 1) },
                    { 121, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assess the site for the university construction.", new DateOnly(2022, 11, 1), false, null, "Conduct Site Assessment", 25, new DateOnly(2022, 11, 1) },
                    { 122, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare initial plans for the university.", new DateOnly(2022, 11, 1), false, null, "Draft Initial Plans", 25, new DateOnly(2022, 11, 1) },
                    { 123, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review plans with stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review with Stakeholders", 25, new DateOnly(2022, 11, 1) },
                    { 124, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire necessary construction permits.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 25, new DateOnly(2022, 11, 1) },
                    { 125, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the university project.", new DateOnly(2022, 11, 1), false, null, "Finalize Budget", 25, new DateOnly(2022, 11, 1) },
                    { 126, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the university.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 26, new DateOnly(2022, 11, 1) },
                    { 127, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the site for university construction.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 26, new DateOnly(2022, 11, 1) },
                    { 128, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start foundation work for the university.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 26, new DateOnly(2022, 11, 1) },
                    { 129, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Construct structural components of the university.", new DateOnly(2022, 11, 1), false, null, "Construct Structural Components", 26, new DateOnly(2022, 11, 1) },
                    { 130, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install the roof structure for the university.", new DateOnly(2022, 11, 1), false, null, "Install Roof Structure", 26, new DateOnly(2022, 11, 1) },
                    { 131, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the university.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 27, new DateOnly(2022, 11, 1) },
                    { 132, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the university.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 27, new DateOnly(2022, 11, 1) },
                    { 133, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install HVAC systems in the university.", new DateOnly(2022, 11, 1), false, null, "Install HVAC Systems", 27, new DateOnly(2022, 11, 1) },
                    { 134, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finish the interiors of the university.", new DateOnly(2022, 11, 1), false, null, "Complete Interior Finishes", 27, new DateOnly(2022, 11, 1) },
                    { 135, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the university for handover to the client.", new DateOnly(2022, 11, 1), false, null, "Prepare for Handover", 27, new DateOnly(2022, 11, 1) },
                    { 136, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evaluate the site for the public park.", new DateOnly(2022, 11, 1), false, null, "Conduct Site Evaluation", 28, new DateOnly(2022, 11, 1) },
                    { 137, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create initial layout for the public park.", new DateOnly(2022, 11, 1), false, null, "Draft Initial Park Layout", 28, new DateOnly(2022, 11, 1) },
                    { 138, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review park layout with community stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review with Stakeholders", 28, new DateOnly(2022, 11, 1) },
                    { 139, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire necessary permits for park construction.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 28, new DateOnly(2022, 11, 1) },
                    { 140, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the public park project.", new DateOnly(2022, 11, 1), false, null, "Finalize Project Budget", 28, new DateOnly(2022, 11, 1) },
                    { 141, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the park.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 29, new DateOnly(2022, 11, 1) },
                    { 142, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the park site for construction.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 29, new DateOnly(2022, 11, 1) },
                    { 143, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start landscaping work for the park.", new DateOnly(2022, 11, 1), false, null, "Begin Landscape Work", 29, new DateOnly(2022, 11, 1) },
                    { 144, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install benches, pathways, and other park amenities.", new DateOnly(2022, 11, 1), false, null, "Install Park Amenities", 29, new DateOnly(2022, 11, 1) },
                    { 145, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete final touches and finishes in the park.", new DateOnly(2022, 11, 1), false, null, "Complete Final Touches", 29, new DateOnly(2022, 11, 1) },
                    { 146, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the public park.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 30, new DateOnly(2022, 11, 1) },
                    { 147, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fix any issues identified during inspections.", new DateOnly(2022, 11, 1), false, null, "Address Any Issues", 30, new DateOnly(2022, 11, 1) },
                    { 148, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the park for the opening ceremony.", new DateOnly(2022, 11, 1), false, null, "Prepare for Opening Ceremony", 30, new DateOnly(2022, 11, 1) },
                    { 149, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Organize an opening event for the community.", new DateOnly(2022, 11, 1), false, null, "Organize Community Event", 30, new DateOnly(2022, 11, 1) },
                    { 150, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evaluate the success of the park project.", new DateOnly(2022, 11, 1), false, null, "Evaluate Project Success", 30, new DateOnly(2022, 11, 1) },
                    { 151, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the train station.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 31, new DateOnly(2022, 11, 1) },
                    { 152, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the train station.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 31, new DateOnly(2022, 11, 1) },
                    { 153, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install HVAC systems in the train station.", new DateOnly(2022, 11, 1), false, null, "Install HVAC Systems", 31, new DateOnly(2022, 11, 1) },
                    { 154, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finish the interiors of the train station.", new DateOnly(2022, 11, 1), false, null, "Complete Interior Finishes", 31, new DateOnly(2022, 11, 1) },
                    { 155, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the train station for handover to the client.", new DateOnly(2022, 11, 1), false, null, "Prepare for Handover", 31, new DateOnly(2022, 11, 1) },
                    { 156, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analyze the market for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Conduct Market Analysis", 32, new DateOnly(2022, 11, 1) },
                    { 157, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create initial layout designs for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Draft Initial Layout", 32, new DateOnly(2022, 11, 1) },
                    { 158, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review designs with stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review with Stakeholders", 32, new DateOnly(2022, 11, 1) },
                    { 159, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire necessary construction permits.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 32, new DateOnly(2022, 11, 1) },
                    { 160, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the shopping center project.", new DateOnly(2022, 11, 1), false, null, "Finalize Project Budget", 32, new DateOnly(2022, 11, 1) },
                    { 161, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 33, new DateOnly(2022, 11, 1) },
                    { 162, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the site for shopping center construction.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 33, new DateOnly(2022, 11, 1) },
                    { 163, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start foundation work for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 33, new DateOnly(2022, 11, 1) },
                    { 164, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Construct structural components of the shopping center.", new DateOnly(2022, 11, 1), false, null, "Construct Structural Components", 33, new DateOnly(2022, 11, 1) },
                    { 165, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install the roof structure for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Install Roof Structure", 33, new DateOnly(2022, 11, 1) },
                    { 166, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the shopping center.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 34, new DateOnly(2022, 11, 1) },
                    { 167, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 34, new DateOnly(2022, 11, 1) },
                    { 168, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 34, new DateOnly(2022, 11, 1) },
                    { 169, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 34, new DateOnly(2022, 11, 1) },
                    { 170, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 34, new DateOnly(2022, 11, 1) },
                    { 171, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assess the site for the university construction.", new DateOnly(2022, 11, 1), false, null, "Conduct Site Assessment", 35, new DateOnly(2022, 11, 1) },
                    { 172, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare initial plans for the university.", new DateOnly(2022, 11, 1), false, null, "Draft Initial Plans", 35, new DateOnly(2022, 11, 1) },
                    { 173, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review plans with stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review with Stakeholders", 35, new DateOnly(2022, 11, 1) },
                    { 174, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire necessary construction permits.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 35, new DateOnly(2022, 11, 1) },
                    { 175, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the university project.", new DateOnly(2022, 11, 1), false, null, "Finalize Budget", 35, new DateOnly(2022, 11, 1) },
                    { 176, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the university.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 36, new DateOnly(2022, 11, 1) },
                    { 177, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the site for university construction.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 36, new DateOnly(2022, 11, 1) },
                    { 178, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start foundation work for the university.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 36, new DateOnly(2022, 11, 1) },
                    { 179, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Construct structural components of the university.", new DateOnly(2022, 11, 1), false, null, "Construct Structural Components", 36, new DateOnly(2022, 11, 1) },
                    { 180, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install the roof structure for the university.", new DateOnly(2022, 11, 1), false, null, "Install Roof Structure", 36, new DateOnly(2022, 11, 1) },
                    { 181, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the university.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 37, new DateOnly(2022, 11, 1) },
                    { 182, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the university.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 37, new DateOnly(2022, 11, 1) },
                    { 183, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install HVAC systems in the university.", new DateOnly(2022, 11, 1), false, null, "Install HVAC Systems", 37, new DateOnly(2022, 11, 1) },
                    { 184, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finish the interiors of the university.", new DateOnly(2022, 11, 1), false, null, "Complete Interior Finishes", 37, new DateOnly(2022, 11, 1) },
                    { 185, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the university for handover to the client.", new DateOnly(2022, 11, 1), false, null, "Prepare for Handover", 37, new DateOnly(2022, 11, 1) },
                    { 186, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evaluate the site for the public park.", new DateOnly(2022, 11, 1), false, null, "Conduct Site Evaluation", 38, new DateOnly(2022, 11, 1) },
                    { 187, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create initial layout for the public park.", new DateOnly(2022, 11, 1), false, null, "Draft Initial Park Layout", 38, new DateOnly(2022, 11, 1) },
                    { 188, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review park layout with community stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review with Stakeholders", 38, new DateOnly(2022, 11, 1) },
                    { 189, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire necessary permits for park construction.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 38, new DateOnly(2022, 11, 1) },
                    { 190, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the public park project.", new DateOnly(2022, 11, 1), false, null, "Finalize Project Budget", 38, new DateOnly(2022, 11, 1) },
                    { 191, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the park.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 39, new DateOnly(2022, 11, 1) },
                    { 192, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the park site for construction.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 39, new DateOnly(2022, 11, 1) },
                    { 193, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start landscaping work for the park.", new DateOnly(2022, 11, 1), false, null, "Begin Landscape Work", 39, new DateOnly(2022, 11, 1) },
                    { 194, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install benches, pathways, and other park amenities.", new DateOnly(2022, 11, 1), false, null, "Install Park Amenities", 39, new DateOnly(2022, 11, 1) },
                    { 195, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete final touches and finishes in the park.", new DateOnly(2022, 11, 1), false, null, "Complete Final Touches", 39, new DateOnly(2022, 11, 1) },
                    { 196, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the public park.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 40, new DateOnly(2022, 11, 1) },
                    { 197, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fix any issues identified during inspections.", new DateOnly(2022, 11, 1), false, null, "Address Any Issues", 40, new DateOnly(2022, 11, 1) },
                    { 198, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the park for the opening ceremony.", new DateOnly(2022, 11, 1), false, null, "Prepare for Opening Ceremony", 40, new DateOnly(2022, 11, 1) },
                    { 199, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Organize an opening event for the community.", new DateOnly(2022, 11, 1), false, null, "Organize Community Event", 40, new DateOnly(2022, 11, 1) },
                    { 200, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evaluate the success of the park project.", new DateOnly(2022, 11, 1), false, null, "Evaluate Project Success", 40, new DateOnly(2022, 11, 1) },
                    { 201, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the train station.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 41, new DateOnly(2022, 11, 1) },
                    { 202, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the train station.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 41, new DateOnly(2022, 11, 1) },
                    { 203, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install HVAC systems in the train station.", new DateOnly(2022, 11, 1), false, null, "Install HVAC Systems", 41, new DateOnly(2022, 11, 1) },
                    { 204, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finish the interiors of the train station.", new DateOnly(2022, 11, 1), false, null, "Complete Interior Finishes", 41, new DateOnly(2022, 11, 1) },
                    { 205, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the train station for handover to the client.", new DateOnly(2022, 11, 1), false, null, "Prepare for Handover", 41, new DateOnly(2022, 11, 1) },
                    { 206, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analyze the market for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Conduct Market Analysis", 42, new DateOnly(2022, 11, 1) },
                    { 207, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create initial layout designs for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Draft Initial Layout", 42, new DateOnly(2022, 11, 1) },
                    { 208, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review designs with stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review with Stakeholders", 42, new DateOnly(2022, 11, 1) },
                    { 209, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire necessary construction permits.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 42, new DateOnly(2022, 11, 1) },
                    { 210, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the shopping center project.", new DateOnly(2022, 11, 1), false, null, "Finalize Project Budget", 42, new DateOnly(2022, 11, 1) },
                    { 211, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 43, new DateOnly(2022, 11, 1) },
                    { 212, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the site for shopping center construction.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 43, new DateOnly(2022, 11, 1) },
                    { 213, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start foundation work for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 43, new DateOnly(2022, 11, 1) },
                    { 214, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Construct structural components of the shopping center.", new DateOnly(2022, 11, 1), false, null, "Construct Structural Components", 43, new DateOnly(2022, 11, 1) },
                    { 215, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install the roof structure for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Install Roof Structure", 43, new DateOnly(2022, 11, 1) },
                    { 216, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the shopping center.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 44, new DateOnly(2022, 11, 1) },
                    { 217, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 44, new DateOnly(2022, 11, 1) },
                    { 218, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 44, new DateOnly(2022, 11, 1) },
                    { 219, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 44, new DateOnly(2022, 11, 1) },
                    { 220, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 44, new DateOnly(2022, 11, 1) },
                    { 221, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assess the site for the university construction.", new DateOnly(2022, 11, 1), false, null, "Conduct Site Assessment", 45, new DateOnly(2022, 11, 1) },
                    { 222, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare initial plans for the university.", new DateOnly(2022, 11, 1), false, null, "Draft Initial Plans", 45, new DateOnly(2022, 11, 1) },
                    { 223, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review plans with stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review with Stakeholders", 45, new DateOnly(2022, 11, 1) },
                    { 224, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire necessary construction permits.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 45, new DateOnly(2022, 11, 1) },
                    { 225, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the university project.", new DateOnly(2022, 11, 1), false, null, "Finalize Budget", 45, new DateOnly(2022, 11, 1) },
                    { 226, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the university.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 46, new DateOnly(2022, 11, 1) },
                    { 227, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the site for university construction.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 46, new DateOnly(2022, 11, 1) },
                    { 228, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start foundation work for the university.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 46, new DateOnly(2022, 11, 1) },
                    { 229, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Construct structural components of the university.", new DateOnly(2022, 11, 1), false, null, "Construct Structural Components", 46, new DateOnly(2022, 11, 1) },
                    { 230, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install the roof structure for the university.", new DateOnly(2022, 11, 1), false, null, "Install Roof Structure", 46, new DateOnly(2022, 11, 1) },
                    { 231, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the university.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 47, new DateOnly(2022, 11, 1) },
                    { 232, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the university.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 47, new DateOnly(2022, 11, 1) },
                    { 233, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install HVAC systems in the university.", new DateOnly(2022, 11, 1), false, null, "Install HVAC Systems", 47, new DateOnly(2022, 11, 1) },
                    { 234, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finish the interiors of the university.", new DateOnly(2022, 11, 1), false, null, "Complete Interior Finishes", 47, new DateOnly(2022, 11, 1) },
                    { 235, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the university for handover to the client.", new DateOnly(2022, 11, 1), false, null, "Prepare for Handover", 47, new DateOnly(2022, 11, 1) },
                    { 236, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evaluate the site for the public park.", new DateOnly(2022, 11, 1), false, null, "Conduct Site Evaluation", 48, new DateOnly(2022, 11, 1) },
                    { 237, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create initial layout for the public park.", new DateOnly(2022, 11, 1), false, null, "Draft Initial Park Layout", 48, new DateOnly(2022, 11, 1) },
                    { 238, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review park layout with community stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review with Stakeholders", 48, new DateOnly(2022, 11, 1) },
                    { 239, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire necessary permits for park construction.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 48, new DateOnly(2022, 11, 1) },
                    { 240, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the public park project.", new DateOnly(2022, 11, 1), false, null, "Finalize Project Budget", 48, new DateOnly(2022, 11, 1) },
                    { 241, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the park.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 49, new DateOnly(2022, 11, 1) },
                    { 242, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the park site for construction.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 49, new DateOnly(2022, 11, 1) },
                    { 243, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start landscaping work for the park.", new DateOnly(2022, 11, 1), false, null, "Begin Landscape Work", 49, new DateOnly(2022, 11, 1) },
                    { 244, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install benches, pathways, and other park amenities.", new DateOnly(2022, 11, 1), false, null, "Install Park Amenities", 49, new DateOnly(2022, 11, 1) },
                    { 245, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete final touches and finishes in the park.", new DateOnly(2022, 11, 1), false, null, "Complete Final Touches", 49, new DateOnly(2022, 11, 1) },
                    { 246, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the public park.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 50, new DateOnly(2022, 11, 1) },
                    { 247, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fix any issues identified during inspections.", new DateOnly(2022, 11, 1), false, null, "Address Any Issues", 50, new DateOnly(2022, 11, 1) },
                    { 248, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the park for the opening ceremony.", new DateOnly(2022, 11, 1), false, null, "Prepare for Opening Ceremony", 50, new DateOnly(2022, 11, 1) },
                    { 249, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Organize an opening event for the community.", new DateOnly(2022, 11, 1), false, null, "Organize Community Event", 50, new DateOnly(2022, 11, 1) },
                    { 250, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evaluate the success of the park project.", new DateOnly(2022, 11, 1), false, null, "Evaluate Project Success", 50, new DateOnly(2022, 11, 1) },
                    { 251, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the train station.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 51, new DateOnly(2022, 11, 1) },
                    { 252, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the train station.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 51, new DateOnly(2022, 11, 1) },
                    { 253, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install HVAC systems in the train station.", new DateOnly(2022, 11, 1), false, null, "Install HVAC Systems", 51, new DateOnly(2022, 11, 1) },
                    { 254, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finish the interiors of the train station.", new DateOnly(2022, 11, 1), false, null, "Complete Interior Finishes", 51, new DateOnly(2022, 11, 1) },
                    { 255, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the train station for handover to the client.", new DateOnly(2022, 11, 1), false, null, "Prepare for Handover", 51, new DateOnly(2022, 11, 1) },
                    { 256, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analyze the market for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Conduct Market Analysis", 52, new DateOnly(2022, 11, 1) },
                    { 257, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create initial layout designs for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Draft Initial Layout", 52, new DateOnly(2022, 11, 1) },
                    { 258, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review designs with stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review with Stakeholders", 52, new DateOnly(2022, 11, 1) },
                    { 259, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire necessary construction permits.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 52, new DateOnly(2022, 11, 1) },
                    { 260, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the shopping center project.", new DateOnly(2022, 11, 1), false, null, "Finalize Project Budget", 52, new DateOnly(2022, 11, 1) },
                    { 261, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 53, new DateOnly(2022, 11, 1) },
                    { 262, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the site for shopping center construction.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 53, new DateOnly(2022, 11, 1) },
                    { 263, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start foundation work for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 53, new DateOnly(2022, 11, 1) },
                    { 264, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Construct structural components of the shopping center.", new DateOnly(2022, 11, 1), false, null, "Construct Structural Components", 53, new DateOnly(2022, 11, 1) },
                    { 265, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install the roof structure for the shopping center.", new DateOnly(2022, 11, 1), false, null, "Install Roof Structure", 53, new DateOnly(2022, 11, 1) },
                    { 266, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the shopping center.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 54, new DateOnly(2022, 11, 1) },
                    { 267, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 54, new DateOnly(2022, 11, 1) },
                    { 268, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 54, new DateOnly(2022, 11, 1) },
                    { 269, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 54, new DateOnly(2022, 11, 1) },
                    { 270, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the shopping center.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 54, new DateOnly(2022, 11, 1) },
                    { 271, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assess the site for the university construction.", new DateOnly(2022, 11, 1), false, null, "Conduct Site Assessment", 55, new DateOnly(2022, 11, 1) },
                    { 272, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare initial plans for the university.", new DateOnly(2022, 11, 1), false, null, "Draft Initial Plans", 55, new DateOnly(2022, 11, 1) },
                    { 273, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review plans with stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review with Stakeholders", 55, new DateOnly(2022, 11, 1) },
                    { 274, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire necessary construction permits.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 55, new DateOnly(2022, 11, 1) },
                    { 275, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the university project.", new DateOnly(2022, 11, 1), false, null, "Finalize Budget", 55, new DateOnly(2022, 11, 1) },
                    { 276, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the university.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 56, new DateOnly(2022, 11, 1) },
                    { 277, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the site for university construction.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 56, new DateOnly(2022, 11, 1) },
                    { 278, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start foundation work for the university.", new DateOnly(2022, 11, 1), false, null, "Begin Foundation Work", 56, new DateOnly(2022, 11, 1) },
                    { 279, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Construct structural components of the university.", new DateOnly(2022, 11, 1), false, null, "Construct Structural Components", 56, new DateOnly(2022, 11, 1) },
                    { 280, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install the roof structure for the university.", new DateOnly(2022, 11, 1), false, null, "Install Roof Structure", 56, new DateOnly(2022, 11, 1) },
                    { 281, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the university.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 57, new DateOnly(2022, 11, 1) },
                    { 282, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install electrical systems in the university.", new DateOnly(2022, 11, 1), false, null, "Install Electrical Systems", 57, new DateOnly(2022, 11, 1) },
                    { 283, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install HVAC systems in the university.", new DateOnly(2022, 11, 1), false, null, "Install HVAC Systems", 57, new DateOnly(2022, 11, 1) },
                    { 284, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finish the interiors of the university.", new DateOnly(2022, 11, 1), false, null, "Complete Interior Finishes", 57, new DateOnly(2022, 11, 1) },
                    { 285, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the university for handover to the client.", new DateOnly(2022, 11, 1), false, null, "Prepare for Handover", 57, new DateOnly(2022, 11, 1) },
                    { 286, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evaluate the site for the public park.", new DateOnly(2022, 11, 1), false, null, "Conduct Site Evaluation", 58, new DateOnly(2022, 11, 1) },
                    { 287, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create initial layout for the public park.", new DateOnly(2022, 11, 1), false, null, "Draft Initial Park Layout", 58, new DateOnly(2022, 11, 1) },
                    { 288, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review park layout with community stakeholders.", new DateOnly(2022, 11, 1), false, null, "Review with Stakeholders", 58, new DateOnly(2022, 11, 1) },
                    { 289, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acquire necessary permits for park construction.", new DateOnly(2022, 11, 1), false, null, "Obtain Necessary Permits", 58, new DateOnly(2022, 11, 1) },
                    { 290, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finalize the budget for the public park project.", new DateOnly(2022, 11, 1), false, null, "Finalize Project Budget", 58, new DateOnly(2022, 11, 1) },
                    { 291, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose a construction team for the park.", new DateOnly(2022, 11, 1), false, null, "Select Construction Team", 59, new DateOnly(2022, 11, 1) },
                    { 292, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the park site for construction.", new DateOnly(2022, 11, 1), false, null, "Prepare Site for Construction", 59, new DateOnly(2022, 11, 1) },
                    { 293, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start landscaping work for the park.", new DateOnly(2022, 11, 1), false, null, "Begin Landscape Work", 59, new DateOnly(2022, 11, 1) },
                    { 294, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install benches, pathways, and other park amenities.", new DateOnly(2022, 11, 1), false, null, "Install Park Amenities", 59, new DateOnly(2022, 11, 1) },
                    { 295, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete final touches and finishes in the park.", new DateOnly(2022, 11, 1), false, null, "Complete Final Touches", 59, new DateOnly(2022, 11, 1) },
                    { 296, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform final inspections of the public park.", new DateOnly(2022, 11, 1), false, null, "Conduct Final Inspection", 60, new DateOnly(2022, 11, 1) },
                    { 297, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fix any issues identified during inspections.", new DateOnly(2022, 11, 1), false, null, "Address Any Issues", 60, new DateOnly(2022, 11, 1) },
                    { 298, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prepare the park for the opening ceremony.", new DateOnly(2022, 11, 1), false, null, "Prepare for Opening Ceremony", 60, new DateOnly(2022, 11, 1) },
                    { 299, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Organize an opening event for the community.", new DateOnly(2022, 11, 1), false, null, "Organize Community Event", 60, new DateOnly(2022, 11, 1) },
                    { 300, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evaluate the success of the park project.", new DateOnly(2022, 11, 1), false, null, "Evaluate Project Success", 60, new DateOnly(2022, 11, 1) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 60);

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

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 20);

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

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
