using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student_marking_system.Migrations.ClgDb
{
    /// <inheritdoc />
    public partial class AttendanceStudentIdString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "studentId",
                table: "attendances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "attendances",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
