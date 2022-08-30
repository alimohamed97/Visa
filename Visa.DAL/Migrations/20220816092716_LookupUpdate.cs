using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visa.DAL.Migrations
{
    public partial class LookupUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "LookUp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "LookUp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
