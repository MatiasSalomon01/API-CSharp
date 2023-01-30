using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestAPI.Migrations
{
    /// <inheritdoc />
    public partial class studentcourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Student",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Student",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Course",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "integer", nullable: false),
                    StudentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Student_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student_Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Course_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Course_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_CityId",
                table: "Student",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Course_CourseId",
                table: "Student_Course",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Course_StudentId",
                table: "Student_Course",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_City_CityId",
                table: "Student",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_City_CityId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "Student_Course");

            migrationBuilder.DropIndex(
                name: "IX_Student_CityId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Course");
        }
    }
}
