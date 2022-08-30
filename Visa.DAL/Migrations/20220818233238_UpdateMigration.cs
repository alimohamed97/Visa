using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visa.DAL.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StampedVisa_StepId",
                table: "StampedVisa",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_StampedVisa_LookUpValue_StepId",
                table: "StampedVisa",
                column: "StepId",
                principalTable: "LookUpValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StampedVisa_LookUpValue_StepId",
                table: "StampedVisa");

            migrationBuilder.DropIndex(
                name: "IX_StampedVisa_StepId",
                table: "StampedVisa");
        }
    }
}
