using Microsoft.EntityFrameworkCore.Migrations;

namespace angularApp.Migrations
{
    public partial class scn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employess_Departments_DepartmentId",
                table: "Employess");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Employess",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employess_Departments_DepartmentId",
                table: "Employess",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employess_Departments_DepartmentId",
                table: "Employess");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Employess",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employess_Departments_DepartmentId",
                table: "Employess",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
