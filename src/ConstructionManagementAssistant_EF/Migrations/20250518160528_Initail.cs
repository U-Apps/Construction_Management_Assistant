using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConstructionManagementAssistant.EF.Migrations
{
    /// <inheritdoc />
    public partial class Initail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClientType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.CheckConstraint("CK_Clients_ClientType", "[ClientType] BETWEEN 1 AND 2");
                });

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

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.CheckConstraint("CK_Equipments_Status", "[Status] BETWEEN 0 AND 3");
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ThirdName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NationalNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkerSpecialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerSpecialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteEngineers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_WorkerSpecialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "WorkerSpecialties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ExpectedEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SiteEngineerId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    SiteAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GeographicalCoordinates = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CancelationReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CancelationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CompletionDate = table.Column<DateOnly>(type: "date", nullable: true),
                    HandoverDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.CheckConstraint("CK_Project_StatusDatesAndReason", "\r\n                            (\r\n                                ([Status] IN (0, 1)) AND [CompletionDate] IS NULL AND [CancelationDate] IS NULL AND [CancelationReason] IS NULL\r\n                            )\r\n                            OR\r\n                            (\r\n                                ([Status] = 2) AND [CompletionDate] IS NOT NULL AND [CancelationDate] IS NULL AND [CancelationReason] IS NULL\r\n                            )\r\n                            OR\r\n                            (\r\n                                ([Status] = 3) AND [CompletionDate] IS NULL AND [CancelationDate] IS NOT NULL AND [CancelationReason] IS NOT NULL\r\n                            )\r\n                        ");
                    table.CheckConstraint("CK_Projects_Status", "[Status] BETWEEN 0 AND 3");
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EquipmentReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentReservations_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentReservations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ExpectedEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stages_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ExpectedEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TaskId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ClassificationId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentClassifications_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "DocumentClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskAssignments",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAssignments", x => new { x.TaskId, x.WorkerId });
                    table.ForeignKey(
                        name: "FK_TaskAssignments_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskAssignments_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ClientType", "CreatedDate", "DeletedDate", "Email", "FullName", "IsDeleted", "ModifiedDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ahmed@example.com", "أحمد محمد", false, null, "1121456789" },
                    { 2, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sara@example.com", "سارة علي", false, null, "2927654321" },
                    { 3, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mohamed@example.com", "محمد حسن", false, null, "31128833445" },
                    { 4, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "leila@example.com", "ليلى إبراهيم", false, null, "4243344556" },
                    { 5, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ali@example.com", "علي يوسف", false, null, "0344455667" },
                    { 6, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fatima@example.com", "فاطمة سعيد", false, null, "5445566778" },
                    { 7, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "khaled@example.com", "خالد عبد الله", false, null, "6556677889" },
                    { 8, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mariam@example.com", "مريم أحمد", false, null, "7667788990" },
                    { 9, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "youssef@example.com", "يوسف علي", false, null, "0878899001" },
                    { 10, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nora@example.com", "نورا محمد", false, null, "9889900112" },
                    { 11, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "hassan@example.com", "حسن علي", false, null, "14490011223" },
                    { 12, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mona@example.com", "منى سعيد", false, null, "01022122334" },
                    { 13, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "omar@example.com", "عمر خالد", false, null, "01112233445" },
                    { 14, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "huda@example.com", "هدى إبراهيم", false, null, "2223344556" },
                    { 15, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "yasser@example.com", "ياسر يوسف", false, null, "03744455667" },
                    { 16, 1, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nadia@example.com", "نادية سعيد", false, null, "0045566778" },
                    { 17, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "majed@example.com", "ماجد عبد الله", false, null, "9956677889" },
                    { 18, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "salma@example.com", "سلمى أحمد", false, null, "0667788990" },
                    { 19, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ziad@example.com", "زياد علي", false, null, "0228899001" },
                    { 20, 2, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "noor@example.com", "نور محمد", false, null, "0874900112" }
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

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "CreatedDate", "Model", "ModifiedDate", "Name", "Notes", "PurchaseDate", "SerialNumber", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAT 320D", null, "Excavator", "Heavy duty excavator for ground work", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "EXC-2023-001", 0 },
                    { 2, new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Komatsu D65PX-18", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bulldozer", "Currently at downtown construction site", new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "BUL-2022-045", 1 },
                    { 3, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Volvo L120H", null, "Wheel Loader", "New addition to fleet", new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "WL-2023-008", 0 },
                    { 4, new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "JCB 3CX", new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Backhoe Loader", "Hydraulic leak detected", new DateTime(2021, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BHL-2021-112", 2 },
                    { 5, new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bobcat S650", null, "Skid Steer Loader", "With pallet forks attachment", new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "SSL-2022-078", 0 },
                    { 6, new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAT 120K", new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Motor Grader", "Road construction project", new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GRD-2020-034", 1 },
                    { 7, new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Volvo A30G", null, "Articulated Dump Truck", "30-ton capacity", new DateTime(2021, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADT-2021-056", 0 },
                    { 8, new DateTime(2019, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAT D6T", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crawler Dozer", "Pending major engine overhaul", new DateTime(2019, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CDZ-2019-023", 3 },
                    { 9, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "JCB 536-70", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Telescopic Handler", "High reach capability", new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "TH-2022-091", 1 },
                    { 10, new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ICE 1412", null, "Pile Driver", "Foundation work equipment", new DateTime(2020, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "PD-2020-017", 0 },
                    { 11, new DateTime(2021, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Putzmeister M42", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concrete Mixer Truck", "9 cubic meter capacity", new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CMT-2021-045", 1 },
                    { 12, new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schwing S36X", null, "Concrete Pump", "Boom pump 36 meters", new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "CP-2022-033", 0 },
                    { 13, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wacker Neuson AR36", null, "Concrete Vibrator", "Internal vibration system", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CV-2023-009", 1 },
                    { 14, new DateTime(2021, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Husqvarna K760", new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concrete Saw", "Blade replacement needed", new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "CS-2021-028", 2 },
                    { 15, new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allen Eng. SP-16", null, "Concrete Finisher", "16-foot finishing width", new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "CF-2020-019", 0 },
                    { 16, new DateTime(2021, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liebherr 63EC", new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tower Crane", "High-rise construction project", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "TC-2021-007", 1 },
                    { 17, new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tadano ATF-220G-5", null, "Mobile Crane", "220-ton capacity", new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "MC-2022-014", 0 },
                    { 18, new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grove RT880E", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rough Terrain Crane", "Annual inspection", new DateTime(2020, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "RTC-2020-026", 2 },
                    { 19, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toyota 8FGCU25", new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forklift", "Warehouse operations", new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FL-2021-038", 1 },
                    { 20, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Genie GS-3246", null, "Scissor Lift", "32ft working height", new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "SL-2022-021", 0 },
                    { 21, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bomag BW211D-40", null, "Vibratory Roller", "For asphalt compaction work", new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "VR-2023-005", 0 },
                    { 22, new DateTime(2021, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wacker Neuson WP1550", new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plate Compactor", "Trench backfilling", new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "PC-2021-029", 1 },
                    { 23, new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vermeer RTX550", null, "Trencher", "Chain-type trencher", new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TR-2020-031", 0 },
                    { 24, new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Volvo ABG6820", new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asphalt Paver", "Screed calibration", new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "AP-2021-042", 2 },
                    { 25, new DateTime(2019, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wirtgen W2000", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cold Planer", "End of service life", new DateTime(2019, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "CP-2019-015", 3 },
                    { 26, new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cummins QSK60", new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generator", "Powering north site operations", new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GEN-2022-032", 1 },
                    { 27, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Atlas Copco XAS185", null, "Air Compressor", "185 cfm capacity", new DateTime(2021, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "AC-2021-027", 0 },
                    { 28, new DateTime(2022, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generac Light Tower", new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Light Tower", "Night shift operations", new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "LT-2022-019", 1 },
                    { 29, new DateTime(2020, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Godwin HL100", null, "Water Pump", "High volume dewatering", new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "WP-2020-024", 0 },
                    { 30, new DateTime(2021, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lincoln Vantage 400", new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welding Machine", "Electrode feeder repair", new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "WM-2021-036", 2 }
                });

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
                table: "SiteEngineers",
                columns: new[] { "Id", "HireDate" },
                values: new object[,]
                {
                    { 21, new DateOnly(2019, 8, 1) },
                    { 22, new DateOnly(2019, 8, 1) },
                    { 23, new DateOnly(2019, 8, 1) },
                    { 24, new DateOnly(2019, 8, 1) },
                    { 25, new DateOnly(2019, 8, 1) },
                    { 26, new DateOnly(2019, 8, 1) },
                    { 27, new DateOnly(2019, 8, 1) },
                    { 28, new DateOnly(2019, 8, 1) },
                    { 29, new DateOnly(2019, 8, 1) },
                    { 30, new DateOnly(2019, 8, 1) },
                    { 31, new DateOnly(2019, 8, 1) },
                    { 32, new DateOnly(2019, 8, 1) },
                    { 33, new DateOnly(2019, 8, 1) },
                    { 34, new DateOnly(2019, 8, 1) },
                    { 35, new DateOnly(2019, 8, 1) },
                    { 36, new DateOnly(2019, 8, 1) },
                    { 37, new DateOnly(2019, 8, 1) },
                    { 38, new DateOnly(2019, 8, 1) },
                    { 39, new DateOnly(2019, 8, 1) },
                    { 40, new DateOnly(2019, 8, 1) }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "SpecialtyId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 1 },
                    { 12, 2 },
                    { 13, 3 },
                    { 14, 4 },
                    { 15, 5 },
                    { 16, 6 },
                    { 17, 7 },
                    { 18, 8 },
                    { 19, 9 },
                    { 20, 10 }
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

            migrationBuilder.CreateIndex(
                name: "UniqueEmail",
                table: "Clients",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UniquePhoneNumber",
                table: "Clients",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UniqueType",
                table: "DocumentClassifications",
                column: "Type",
                unique: true,
                filter: "[Type] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ClassificationId",
                table: "Documents",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ProjectId",
                table: "Documents",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TaskId",
                table: "Documents",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "UniquePath",
                table: "Documents",
                column: "Path",
                unique: true,
                filter: "[Path] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UniqueTitle",
                table: "Documents",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentReservations_EquipmentId",
                table: "EquipmentReservations",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentReservations_ProjectId",
                table: "EquipmentReservations",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "UniqueEmail",
                table: "People",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UniqueNationalNumber",
                table: "People",
                column: "NationalNumber",
                unique: true,
                filter: "[NationalNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UniquePhoneNumber",
                table: "People",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_SiteEngineerId",
                table: "Projects",
                column: "SiteEngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_ProjectId",
                table: "Stages",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignments_WorkerId",
                table: "TaskAssignments",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StageId",
                table: "Tasks",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_SpecialtyId",
                table: "Workers",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "UniqueSpecialtyName",
                table: "WorkerSpecialties",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "EquipmentReservations");

            migrationBuilder.DropTable(
                name: "TaskAssignments");

            migrationBuilder.DropTable(
                name: "DocumentClassifications");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "WorkerSpecialties");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "SiteEngineers");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
