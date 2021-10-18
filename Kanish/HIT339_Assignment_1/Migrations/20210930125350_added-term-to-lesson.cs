using Microsoft.EntityFrameworkCore.Migrations;

namespace HIT339_Assignment_1.Migrations
{
    public partial class addedtermtolesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Lesson");
        }
    }
}
