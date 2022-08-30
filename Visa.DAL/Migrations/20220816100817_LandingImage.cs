using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visa.DAL.Migrations
{
    public partial class LandingImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "StampedVisa",
                newName: "ImageName");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Landing",
                newName: "ImageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "StampedVisa",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Landing",
                newName: "Image");
        }
    }
}
