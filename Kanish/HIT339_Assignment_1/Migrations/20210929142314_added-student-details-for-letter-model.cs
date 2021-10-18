using Microsoft.EntityFrameworkCore.Migrations;

namespace HIT339_Assignment_1.Migrations
{
    public partial class addedstudentdetailsforlettermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentDetails",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentDetails",
                table: "Letter");
        }
    }
}
