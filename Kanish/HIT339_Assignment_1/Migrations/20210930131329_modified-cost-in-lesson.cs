using Microsoft.EntityFrameworkCore.Migrations;

namespace HIT339_Assignment_1.Migrations
{
    public partial class modifiedcostinlesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Lesson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Lesson",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
