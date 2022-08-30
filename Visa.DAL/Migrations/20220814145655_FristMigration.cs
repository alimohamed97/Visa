using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visa.DAL.Migrations
{
    public partial class FristMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TESTIMONIALS_Ar",
                table: "Header",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TESTIMONIALS_En",
                table: "Header",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TESTIMONIALS_Ar",
                table: "Header");

            migrationBuilder.DropColumn(
                name: "TESTIMONIALS_En",
                table: "Header");
        }
    }
}
