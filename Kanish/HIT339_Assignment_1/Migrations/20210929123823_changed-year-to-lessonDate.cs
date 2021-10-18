using Microsoft.EntityFrameworkCore.Migrations;

namespace HIT339_Assignment_1.Migrations
{
    public partial class changedyeartolessonDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Lesson",
                newName: "LessonDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LessonDate",
                table: "Lesson",
                newName: "Year");
        }
    }
}
