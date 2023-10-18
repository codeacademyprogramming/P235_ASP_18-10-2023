using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MentorApp.Migrations
{
    public partial class UpdatedCourseSectionsTableRelatedCoursesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "CourseSections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourseSections_CourseId",
                table: "CourseSections",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSections_Courses_CourseId",
                table: "CourseSections",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSections_Courses_CourseId",
                table: "CourseSections");

            migrationBuilder.DropIndex(
                name: "IX_CourseSections_CourseId",
                table: "CourseSections");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CourseSections");
        }
    }
}
