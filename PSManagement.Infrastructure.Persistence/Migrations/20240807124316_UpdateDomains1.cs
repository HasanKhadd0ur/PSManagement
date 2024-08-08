using Microsoft.EntityFrameworkCore.Migrations;

namespace PSManagement.Infrastructure.Persistence.Migrations
{
    public partial class UpdateDomains1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Tracks_TrackId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TrackId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrackId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TrackId",
                table: "Employees",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Tracks_TrackId",
                table: "Employees",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
