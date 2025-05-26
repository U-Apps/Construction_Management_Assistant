using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementAssistant.EF.Migrations
{
    /// <inheritdoc />
    public partial class SeedProjectsInEnglish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a primary school in the city", "School Construction Project", "City, Street 1" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a general hospital in the city", "Hospital Construction Project", "City, Street 2" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a luxury residential complex", "Residential Complex Construction Project", "City, Street 3" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a bridge connecting two areas", "Bridge Construction Project", "City, Street 4" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a food production factory", "Factory Construction Project", "City, Street 5" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a five-star hotel", "Hotel Construction Project", "City, Street 6" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a modern train station", "Train Station Construction Project", "City, Street 7" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a large shopping mall", "Shopping Mall Construction Project", "City, Street 8" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a modern university", "University Construction Project", "City, Street 9" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a large public park", "Public Park Construction Project", "City, Street 10" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a public library in the city", "Public Library Construction Project", "City, Street 11" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a modern sports stadium", "Sports Stadium Construction Project", "City, Street 12" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a modern gas station", "Gas Station Construction Project", "City, Street 13" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a health center in the city", "Health Center Construction Project", "City, Street 14" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a large commercial complex", "Commercial Complex Construction Project", "City, Street 15" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a modern power plant", "Power Plant Construction Project", "City, Street 16" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a modern water plant", "Water Plant Construction Project", "City, Street 17" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "Construction of a modern police station", "Police Station Construction Project", "City, Street 18" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CancelationReason", "Description", "Name", "SiteAddress" },
                values: new object[] { "Project was cancelled due to lack of funding", "Construction of a modern fire station", "Fire Station Construction Project", "City, Street 19" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CancelationReason", "Description", "Name", "SiteAddress" },
                values: new object[] { "Project was cancelled due to changing priorities", "Construction of a modern cultural center", "Cultural Center Construction Project", "City, Street 20" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء مدرسة ابتدائية في المدينة", "مشروع بناء مدرسة", "المدينة، شارع 1" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء مستشفى عام في المدينة", "مشروع بناء مستشفى", "المدينة، شارع 2" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء مجمع سكني فاخر", "مشروع بناء مجمع سكني", "المدينة، شارع 3" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء جسر يربط بين منطقتين", "مشروع بناء جسر", "المدينة، شارع 4" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء مصنع لإنتاج المواد الغذائية", "مشروع بناء مصنع", "المدينة، شارع 5" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء فندق خمس نجوم", "مشروع بناء فندق", "المدينة، شارع 6" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء محطة قطار حديثة", "مشروع بناء محطة قطار", "المدينة، شارع 7" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء مركز تجاري ضخم", "مشروع بناء مركز تجاري", "المدينة، شارع 8" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء جامعة حديثة", "مشروع بناء جامعة", "المدينة، شارع 9" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء حديقة عامة كبيرة", "مشروع بناء حديقة عامة", "المدينة، شارع 10" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء مكتبة عامة في المدينة", "مشروع بناء مكتبة عامة", "المدينة، شارع 11" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء ملعب رياضي حديث", "مشروع بناء ملعب رياضي", "المدينة، شارع 12" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء محطة وقود حديثة", "مشروع بناء محطة وقود", "المدينة، شارع 13" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء مركز صحي في المدينة", "مشروع بناء مركز صحي", "المدينة، شارع 14" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء مجمع تجاري ضخم", "مشروع بناء مجمع تجاري", "المدينة، شارع 15" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء محطة كهرباء حديثة", "مشروع بناء محطة كهرباء", "المدينة، شارع 16" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء محطة مياه حديثة", "مشروع بناء محطة مياه", "المدينة، شارع 17" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "Name", "SiteAddress" },
                values: new object[] { "بناء مركز شرطة حديث", "مشروع بناء مركز شرطة", "المدينة، شارع 18" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CancelationReason", "Description", "Name", "SiteAddress" },
                values: new object[] { "تم إلغاء المشروع بسبب نقص التمويل", "بناء محطة إطفاء حديثة", "مشروع بناء محطة إطفاء", "المدينة، شارع 19" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CancelationReason", "Description", "Name", "SiteAddress" },
                values: new object[] { "تم إلغاء المشروع بسبب تغير الأولويات", "بناء مركز ثقافي حديث", "مشروع بناء مركز ثقافي", "المدينة، شارع 20" });
        }
    }
}
