using Microsoft.EntityFrameworkCore.Migrations;

namespace PSManagement.Infrastructure.Persistence.Migrations
{
    public partial class AddParticipationHistory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StepInfo_NumberOfWorker",
                table: "Steps",
                newName: "NumberOfWorker");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfWorker",
                table: "Steps",
                newName: "StepInfo_NumberOfWorker");
        }
    }
}
