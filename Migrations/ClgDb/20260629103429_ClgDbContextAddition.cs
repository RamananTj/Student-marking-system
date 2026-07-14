using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_marking_system.Migrations.ClgDb
{
    /// <inheritdoc />
    public partial class ClgDbContextAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attendances",
                columns: table => new
                {
                    attendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendances", x => x.attendanceId);
                });

            migrationBuilder.CreateTable(
                name: "marks",
                columns: table => new
                {
                    MarksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subjectId = table.Column<int>(type: "int", nullable: false),
                    internalMark = table.Column<int>(type: "int", nullable: false),
                    externalMark = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marks", x => x.MarksId);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    subjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    credits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.subjectId);
                });

            migrationBuilder.CreateTable(
                name: "studentSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    subjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentSubjects_subjects_subjectId",
                        column: x => x.subjectId,
                        principalTable: "subjects",
                        principalColumn: "subjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjects_subjectId",
                table: "studentSubjects",
                column: "subjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attendances");

            migrationBuilder.DropTable(
                name: "marks");

            migrationBuilder.DropTable(
                name: "studentSubjects");

            migrationBuilder.DropTable(
                name: "subjects");
        }
    }
}
