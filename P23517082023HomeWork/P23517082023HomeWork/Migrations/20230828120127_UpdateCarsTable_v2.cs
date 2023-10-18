using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P23517082023HomeWork.Migrations
{
    public partial class UpdateCarsTable_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Cars",
                newName: "Qiymet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Qiymet",
                table: "Cars",
                newName: "Price");
        }
    }
}
