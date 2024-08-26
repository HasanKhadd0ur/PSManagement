using Microsoft.EntityFrameworkCore.Migrations;

namespace PSManagement.Infrastructure.Persistence.Migrations
{
    public partial class AddParticipationHistory1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ParticipationChanges_EmployeeId",
                table: "ParticipationChanges");

            migrationBuilder.DropIndex(
                name: "IX_ParticipationChanges_ProjectId",
                table: "ParticipationChanges");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipationChanges_EmployeeId",
                table: "ParticipationChanges",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipationChanges_ProjectId",
                table: "ParticipationChanges",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ParticipationChanges_EmployeeId",
                table: "ParticipationChanges");

            migrationBuilder.DropIndex(
                name: "IX_ParticipationChanges_ProjectId",
                table: "ParticipationChanges");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipationChanges_EmployeeId",
                table: "ParticipationChanges",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParticipationChanges_ProjectId",
                table: "ParticipationChanges",
                column: "ProjectId",
                unique: true);
        }
    }
}
