using Microsoft.EntityFrameworkCore.Migrations;

namespace PSManagement.Infrastructure.Persistence.Migrations
{
    public partial class AddDomains6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Tracks_TrackId",
                table: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_Steps_TrackId",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "Steps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrackId",
                table: "Steps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Steps_TrackId",
                table: "Steps",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Tracks_TrackId",
                table: "Steps",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
