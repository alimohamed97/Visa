using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visa.DAL.Migrations
{
    public partial class Lookups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookUp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_En = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookUpValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookUpValue_LookUp_ParentId",
                        column: x => x.ParentId,
                        principalTable: "LookUp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookUpValue_ParentId",
                table: "LookUpValue",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LookUpValue");

            migrationBuilder.DropTable(
                name: "LookUp");
        }
    }
}
