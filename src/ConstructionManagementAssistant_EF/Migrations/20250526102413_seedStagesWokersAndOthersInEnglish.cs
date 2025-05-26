using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementAssistant.EF.Migrations
{
    /// <inheritdoc />
    public partial class seedStagesWokersAndOthersInEnglish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "FullName",
                value: "Ahmed Mohamed");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "FullName",
                value: "Sara Ali");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "FullName",
                value: "Mohamed Hassan");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "FullName",
                value: "Leila Ibrahim");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "FullName",
                value: "Ali Youssef");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "FullName",
                value: "Fatima Saeed");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "FullName",
                value: "Khaled Abdullah");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "FullName",
                value: "Mariam Ahmed");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "FullName",
                value: "Youssef Ali");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "FullName",
                value: "Nora Mohamed");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "FullName",
                value: "Hassan Ali");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "FullName",
                value: "Mona Saeed");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "FullName",
                value: "Omar Khaled");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "FullName",
                value: "Huda Ibrahim");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "FullName",
                value: "Yasser Youssef");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "FullName",
                value: "Nadia Saeed");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "FullName",
                value: "Majed Abdullah");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "FullName",
                value: "Salma Ahmed");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 19,
                column: "FullName",
                value: "Ziad Ali");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 20,
                column: "FullName",
                value: "Noor Mohamed");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 10, Riyadh", "mohamed@example.com", "Mohammed", "Al-Khalid", "Ali", "Hassan" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 20, Jeddah", "ahmed@example.com", "Ahmed", "Al-Fahid", "Khalid", "Saeed" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 30, Makkah", "ali@example.com", "Ali", "Al-Ghamdi", "Yasser", "Tariq" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 40, Madinah", "khalid@example.com", "Khalid", "Al-Saeed", "Omar", "Mustafa" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 50, Dammam", "yasser@example.com", "Yasser", "Al-Najjar", "Hassan", "Saad" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 60, Khobar", "tariq@example.com", "Tariq", "Al-Zaid", "Saeed", "Mohammed" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 70, Taif", "mustafa@example.com", "Mustafa", "Al-Obaid", "Abdullah", "Ahmed" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 80, Tabuk", "saeed@example.com", "Saeed", "Al-Rashid", "Ali", "Khalid" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 90, Buraidah", "omar@example.com", "Omar", "Al-Ghamdi", "Yasser", "Tariq" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 100, Hail", "hassan@example.com", "Hassan", "Al-Fahid", "Mohammed", "Ahmed" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 110, Riyadh", "fahad@example.com", "Fahad", "Al-Obaid", "Abdulrahman", "Nasser" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 120, Jeddah", "nasser@example.com", "Nasser", "Al-Zaid", "Salman", "Faisal" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 130, Makkah", "faisal@example.com", "Faisal", "Al-Rashid", "Abdulaziz", "Rashed" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Address", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 140, Madinah", "Rashed", "Al-Saad", "Abdullah", "Saad" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Address", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 150, Dammam", "Saad", "Al-Fahad", "Abdulmohsen", "Fahad" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Address", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 160, Khobar", "Abdullah", "Al-Nasser", "Abdulrahman", "Nasser" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Address", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 170, Taif", "Abdulrahman", "Al-Rashed", "Faisal", "Rashed" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Address", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 180, Tabuk", "Abdulaziz", "Al-Fahad", "Saad", "Fahad" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Address", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 190, Buraidah", "Salman", "Al-Abdullah", "Rashed", "Abdullah" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Address", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "Street 200, Hail", "Abdulmohsen", "Al-Nasser", "Fahad", "Nasser" });

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Design");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Construction");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Finishing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Design");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Construction");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Finishing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Design");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Construction");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Finishing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Design");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Construction");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Finishing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Design");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Construction");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Finishing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Design");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Construction");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Finishing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "Design");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Construction");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Finishing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Design");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "Construction");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Finishing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Design");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Construction");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Finishing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Design");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Construction");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "Finishing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "Planning");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Execution");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "Final Testing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "Planning");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "Execution");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "Final Testing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 37,
                column: "Name",
                value: "Planning");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 38,
                column: "Name",
                value: "Execution");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 39,
                column: "Name",
                value: "Final Testing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 40,
                column: "Name",
                value: "Planning");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 41,
                column: "Name",
                value: "Execution");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 42,
                column: "Name",
                value: "Final Testing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 43,
                column: "Name",
                value: "Planning");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 44,
                column: "Name",
                value: "Execution");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 45,
                column: "Name",
                value: "Final Testing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 46,
                column: "Name",
                value: "Planning");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 47,
                column: "Name",
                value: "Execution");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 48,
                column: "Name",
                value: "Final Testing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "Planning");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 50,
                column: "Name",
                value: "Execution");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "Final Testing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 52,
                column: "Name",
                value: "Planning");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 53,
                column: "Name",
                value: "Execution");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 54,
                column: "Name",
                value: "Final Testing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 55,
                column: "Name",
                value: "Planning");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 56,
                column: "Name",
                value: "Execution");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 57,
                column: "Name",
                value: "Final Testing");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 58,
                column: "Name",
                value: "Planning");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 59,
                column: "Name",
                value: "Execution");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 60,
                column: "Name",
                value: "Final Testing");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Ahmed Mohammed");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Sarah Ali");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "Mohammed Hassan");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Layla Ibrahim");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Ali Youssef");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Fatima Saeed");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Khalid Abdullah");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Mariam Ahmed");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Youssef Ali");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "Nora Mohammed");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "Hassan Ali");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Mona Saeed");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "Omar Khalid");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "Huda Ibrahim");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "Yasser Youssef");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "Nadia Saeed");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 37,
                column: "Name",
                value: "Majed Abdullah");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 38,
                column: "Name",
                value: "Salma Ahmed");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 39,
                column: "Name",
                value: "Ziad Ali");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 40,
                column: "Name",
                value: "Noor Mohammed");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Carpenter");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Blacksmith");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Plumber");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Electrician");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Builder");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Painter");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Tiler");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Contractor");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Architect");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Civil Engineer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "FullName",
                value: "أحمد محمد");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "FullName",
                value: "سارة علي");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "FullName",
                value: "محمد حسن");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "FullName",
                value: "ليلى إبراهيم");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "FullName",
                value: "علي يوسف");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "FullName",
                value: "فاطمة سعيد");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "FullName",
                value: "خالد عبد الله");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "FullName",
                value: "مريم أحمد");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "FullName",
                value: "يوسف علي");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "FullName",
                value: "نورا محمد");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "FullName",
                value: "حسن علي");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "FullName",
                value: "منى سعيد");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "FullName",
                value: "عمر خالد");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "FullName",
                value: "هدى إبراهيم");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "FullName",
                value: "ياسر يوسف");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "FullName",
                value: "نادية سعيد");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "FullName",
                value: "ماجد عبد الله");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "FullName",
                value: "سلمى أحمد");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 19,
                column: "FullName",
                value: "زياد علي");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 20,
                column: "FullName",
                value: "نور محمد");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 10, الرياض", "mohamedd@example.com", "محمد", "الخالد", "علي", "حسن" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 20, جدة", "ahmedd@example.com", "أحمد", "الفهيد", "خالد", "سعيد" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 30, مكة", "aliee@example.com", "علي", "الغامدي", "ياسر", "طارق" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 40, المدينة", "khassled@example.com", "خالد", "السعيد", "عمر", "مصطفى" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 50, الدمام", "yas4ser@example.com", "ياسر", "النجار", "حسن", "سعد" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 60, الخبر", "taridq@example.com", "طارق", "الزيد", "سعيد", "محمد" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 70, الطائف", "mustaffa@example.com", "مصطفى", "العبيد", "عبدالله", "أحمد" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 80, تبوك", "saeefd@example.com", "سعيد", "الرشيد", "علي", "خالد" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 90, بريدة", "omar@examp2le.com", "عمر", "الغامدي", "ياسر", "طارق" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 100, حائل", "hass2an@example.com", "حسن", "الفهيد", "محمد", "أحمد" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 110, الرياض", "fahad@exam2ple.com", "فهد", "العبيد", "عبدالرحمن", "ناصر" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 120, جدة", "nasse2r@example.com", "ناصر", "الزيد", "سلمان", "فيصل" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Address", "Email", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 130, مكة", "faidsal@example.com", "فيصل", "الرشيد", "عبدالعزيز", "راشد" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Address", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 140, المدينة", "راشد", "السعد", "عبدالله", "سعد" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Address", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 150, الدمام", "سعد", "الفهد", "عبدالمحسن", "فهد" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Address", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 160, الخبر", "عبدالله", "الناصر", "عبدالرحمن", "ناصر" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Address", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 170, الطائف", "عبدالرحمن", "الراشد", "فيصل", "راشد" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Address", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 180, تبوك", "عبدالعزيز", "الفهد", "سعد", "فهد" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Address", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 190, بريدة", "سلمان", "العبدالله", "راشد", "عبدالله" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Address", "FirstName", "LastName", "SecondName", "ThirdName" },
                values: new object[] { "شارع 200, حائل", "عبدالمحسن", "الناصر", "فهد", "ناصر" });

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "تصميم");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "بناء");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "تشطيب");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "تصميم");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "بناء");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "تشطيب");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "تصميم");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "بناء");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "تشطيب");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "تصميم");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "بناء");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "تشطيب");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "تصميم");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "بناء");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "تشطيب");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "تصميم");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "بناء");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "تشطيب");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "تصميم");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "بناء");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "تشطيب");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "تصميم");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "بناء");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "تشطيب");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "تصميم");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "بناء");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "تشطيب");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "تصميم");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "بناء");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "تشطيب");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "التخطيط");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "التنفيذ");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "الفحص النهائي");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "التخطيط");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "التنفيذ");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "الفحص النهائي");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 37,
                column: "Name",
                value: "التخطيط");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 38,
                column: "Name",
                value: "التنفيذ");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 39,
                column: "Name",
                value: "الفحص النهائي");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 40,
                column: "Name",
                value: "التخطيط");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 41,
                column: "Name",
                value: "التنفيذ");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 42,
                column: "Name",
                value: "الفحص النهائي");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 43,
                column: "Name",
                value: "التخطيط");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 44,
                column: "Name",
                value: "التنفيذ");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 45,
                column: "Name",
                value: "الفحص النهائي");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 46,
                column: "Name",
                value: "التخطيط");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 47,
                column: "Name",
                value: "التنفيذ");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 48,
                column: "Name",
                value: "الفحص النهائي");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "التخطيط");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 50,
                column: "Name",
                value: "التنفيذ");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "الفحص النهائي");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 52,
                column: "Name",
                value: "التخطيط");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 53,
                column: "Name",
                value: "التنفيذ");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 54,
                column: "Name",
                value: "الفحص النهائي");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 55,
                column: "Name",
                value: "التخطيط");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 56,
                column: "Name",
                value: "التنفيذ");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 57,
                column: "Name",
                value: "الفحص النهائي");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 58,
                column: "Name",
                value: "التخطيط");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 59,
                column: "Name",
                value: "التنفيذ");

            migrationBuilder.UpdateData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 60,
                column: "Name",
                value: "الفحص النهائي");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "أحمد محمد");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "سارة علي");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "محمد حسن");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "ليلى إبراهيم");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "علي يوسف");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "فاطمة سعيد");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "خالد عبد الله");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "مريم أحمد");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "يوسف علي");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "نورا محمد");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "حسن علي");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "منى سعيد");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "عمر خالد");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "هدى إبراهيم");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "ياسر يوسف");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "نادية سعيد");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 37,
                column: "Name",
                value: "ماجد عبد الله");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 38,
                column: "Name",
                value: "سلمى أحمد");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 39,
                column: "Name",
                value: "زياد علي");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 40,
                column: "Name",
                value: "نور محمد");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "نجار");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "حداد");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "سباك");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "كهربائي");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "بناء");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "دهان");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "مبلط");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "مقاول");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "مهندس معماري");

            migrationBuilder.UpdateData(
                table: "WorkerSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "مهندس مدني");
        }
    }
}
