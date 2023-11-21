using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBIG.Migrations
{
    public partial class inialCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Dnumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Dnumber);
                });

            migrationBuilder.CreateTable(
                name: "Dept_Locs",
                columns: table => new
                {
                    Dnumber = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dept_Locs", x => new { x.Dnumber, x.Location });
                    table.ForeignKey(
                        name: "FK_Dept_Locs_Departments_Dnumber",
                        column: x => x.Dnumber,
                        principalTable: "Departments",
                        principalColumn: "Dnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    SuperSSN = table.Column<int>(type: "int", nullable: true),
                    Dnumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_Dnumber",
                        column: x => x.Dnumber,
                        principalTable: "Departments",
                        principalColumn: "Dnumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_SuperSSN",
                        column: x => x.SuperSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    PNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNUM = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.PNumber);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DNUM",
                        column: x => x.DNUM,
                        principalTable: "Departments",
                        principalColumn: "Dnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Depandents",
                columns: table => new
                {
                    ESSN = table.Column<int>(type: "int", nullable: false),
                    DEPENDENTNAME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BDATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RELATIONSHIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeSSN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depandents", x => new { x.ESSN, x.DEPENDENTNAME });
                    table.ForeignKey(
                        name: "FK_Depandents_Employees_EmployeeSSN",
                        column: x => x.EmployeeSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "Works_ONs",
                columns: table => new
                {
                    ESSN = table.Column<int>(type: "int", nullable: false),
                    PNO = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works_ONs", x => new { x.ESSN, x.PNO });
                    table.ForeignKey(
                        name: "FK_Works_ONs_Employees_ESSN",
                        column: x => x.ESSN,
                        principalTable: "Employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Works_ONs_Projects_PNO",
                        column: x => x.PNO,
                        principalTable: "Projects",
                        principalColumn: "PNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Depandents_EmployeeSSN",
                table: "Depandents",
                column: "EmployeeSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Dnumber",
                table: "Employees",
                column: "Dnumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SuperSSN",
                table: "Employees",
                column: "SuperSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DNUM",
                table: "Projects",
                column: "DNUM");

            migrationBuilder.CreateIndex(
                name: "IX_Works_ONs_PNO",
                table: "Works_ONs",
                column: "PNO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Depandents");

            migrationBuilder.DropTable(
                name: "Dept_Locs");

            migrationBuilder.DropTable(
                name: "Works_ONs");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
