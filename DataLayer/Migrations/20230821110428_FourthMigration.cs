using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Course_CourseId",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Question",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_CourseId",
                table: "Question",
                newName: "IX_Question_SubjectId");

            migrationBuilder.RenameColumn(
                name: "CourseName",
                table: "Course",
                newName: "SubjectName");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Course",
                newName: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Course_SubjectId",
                table: "Question",
                column: "SubjectId",
                principalTable: "Course",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Course_SubjectId",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Question",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_SubjectId",
                table: "Question",
                newName: "IX_Question_CourseId");

            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "Course",
                newName: "CourseName");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Course",
                newName: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Course_CourseId",
                table: "Question",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
