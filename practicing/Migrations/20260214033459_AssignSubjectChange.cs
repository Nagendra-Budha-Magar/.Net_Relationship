using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practicing.Migrations
{
    /// <inheritdoc />
    public partial class AssignSubjectChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Semesters_semesterId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Semester_Subjects");

            migrationBuilder.AlterColumn<int>(
                name: "semesterId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AssignSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    semesterId = table.Column<int>(type: "int", nullable: false),
                    subjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignSubjects_Semesters_semesterId",
                        column: x => x.semesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignSubjects_Subjects_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignSubjects_semesterId",
                table: "AssignSubjects",
                column: "semesterId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignSubjects_subjectId",
                table: "AssignSubjects",
                column: "subjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Semesters_semesterId",
                table: "Students",
                column: "semesterId",
                principalTable: "Semesters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Semesters_semesterId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "AssignSubjects");

            migrationBuilder.AlterColumn<int>(
                name: "semesterId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Semester_Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    semesterId = table.Column<int>(type: "int", nullable: false),
                    subjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semester_Subjects_Semesters_semesterId",
                        column: x => x.semesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Semester_Subjects_Subjects_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Semester_Subjects_semesterId",
                table: "Semester_Subjects",
                column: "semesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_Subjects_subjectId",
                table: "Semester_Subjects",
                column: "subjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Semesters_semesterId",
                table: "Students",
                column: "semesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
