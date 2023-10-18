using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MentorApp.Migrations
{
    public partial class UpdatedTrainersTableRelatedCategoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategroyId",
                table: "Trainers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_CategroyId",
                table: "Trainers",
                column: "CategroyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Categroys_CategroyId",
                table: "Trainers",
                column: "CategroyId",
                principalTable: "Categroys",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Categroys_CategroyId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_CategroyId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "CategroyId",
                table: "Trainers");
        }
    }
}
