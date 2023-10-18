using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MentorApp.Migrations
{
    public partial class UpdatedCourseTableRelatedTrainersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TrainerId",
                table: "Courses",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Trainers_TrainerId",
                table: "Courses",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Trainers_TrainerId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TrainerId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Courses");
        }
    }
}
