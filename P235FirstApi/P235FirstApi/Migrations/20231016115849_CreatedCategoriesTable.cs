using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P235FirstApi.Migrations
{
    public partial class CreatedCategoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "System"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "Image", "IsDeleted", "IsMain", "Name", "ParentId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, null, null, "sekil1.jpg", false, false, "Phone", null, null, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "Image", "IsDeleted", "IsMain", "Name", "ParentId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 2, null, null, "sekil1.jpg", false, false, "Computer", null, null, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "Image", "IsDeleted", "IsMain", "Name", "ParentId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 3, null, null, "sekil1.jpg", false, false, "Televizor", null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
