using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace New_Era.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Insractor_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstManage",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Instractors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AddressEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instractors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instractors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instractors_Instractors_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Instractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstractorSubjects",
                columns: table => new
                {
                    InstractorId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstractorSubjects", x => new { x.SubjectId, x.InstractorId });
                    table.ForeignKey(
                        name: "FK_InstractorSubjects_Instractors_InstractorId",
                        column: x => x.InstractorId,
                        principalTable: "Instractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstractorSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InstManage",
                table: "Departments",
                column: "InstManage",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instractors_DepartmentId",
                table: "Instractors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instractors_SupervisorId",
                table: "Instractors",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstractorSubjects_InstractorId",
                table: "InstractorSubjects",
                column: "InstractorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instractors_InstManage",
                table: "Departments",
                column: "InstManage",
                principalTable: "Instractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instractors_InstManage",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "InstractorSubjects");

            migrationBuilder.DropTable(
                name: "Instractors");

            migrationBuilder.DropIndex(
                name: "IX_Departments_InstManage",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "InstManage",
                table: "Departments");
        }
    }
}
