using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visa.DAL.Migrations
{
    public partial class TestMonials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TESTIMONIALS_Ar",
                table: "Header");

            migrationBuilder.DropColumn(
                name: "TESTIMONIALS_En",
                table: "Header");

            migrationBuilder.CreateTable(
                name: "HomeTestimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_En = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeTestimonials", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeTestimonials");

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
    }
}
