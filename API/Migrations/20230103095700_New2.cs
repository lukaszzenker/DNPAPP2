using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class New2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "studentId",
                table: "Grades",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_studentId",
                table: "Grades",
                column: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_studentId",
                table: "Grades",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "studentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_studentId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_studentId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "studentId",
                table: "Grades");
        }
    }
}
