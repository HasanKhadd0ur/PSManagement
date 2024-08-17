using Microsoft.EntityFrameworkCore.Migrations;

namespace PSManagement.Infrastructure.Persistence.Migrations
{
    public partial class FixProjectEntity1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExecutionRatio",
                table: "StepTracks",
                newName: "TrackExecutionRatio");

            migrationBuilder.AddColumn<int>(
                name: "OldExecutionRatio",
                table: "StepTracks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OldExecutionRatio",
                table: "StepTracks");

            migrationBuilder.RenameColumn(
                name: "TrackExecutionRatio",
                table: "StepTracks",
                newName: "ExecutionRatio");
        }
    }
}
