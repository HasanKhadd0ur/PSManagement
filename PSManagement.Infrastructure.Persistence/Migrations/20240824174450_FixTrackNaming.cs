using Microsoft.EntityFrameworkCore.Migrations;

namespace PSManagement.Infrastructure.Persistence.Migrations
{
    public partial class FixTrackNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTrack_Employees_EmloyeeId",
                table: "EmployeeTrack");

            migrationBuilder.RenameColumn(
                name: "EmloyeeId",
                table: "EmployeeTrack",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTrack_EmloyeeId",
                table: "EmployeeTrack",
                newName: "IX_EmployeeTrack_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTrack_Employees_EmployeeId",
                table: "EmployeeTrack",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTrack_Employees_EmployeeId",
                table: "EmployeeTrack");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "EmployeeTrack",
                newName: "EmloyeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTrack_EmployeeId",
                table: "EmployeeTrack",
                newName: "IX_EmployeeTrack_EmloyeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTrack_Employees_EmloyeeId",
                table: "EmployeeTrack",
                column: "EmloyeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
