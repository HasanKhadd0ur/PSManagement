using Microsoft.EntityFrameworkCore.Migrations;

namespace PSManagement.Infrastructure.Persistence.Migrations
{
    public partial class AddDomainUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Steps_StepId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorks_Employees_EmployeeId",
                table: "EmployeeWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorks_StepTracks_StepTrackId",
                table: "EmployeeWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Steps_StepId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_StepId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StepId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "StepId",
                table: "Employees",
                newName: "TrackId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_StepId",
                table: "Employees",
                newName: "IX_Employees_TrackId");

            migrationBuilder.AddColumn<int>(
                name: "ExecutionRatio",
                table: "StepTracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentCompletionRatio",
                table: "Steps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Steps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EmployeeParticipate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    PartialTimeRatio = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeParticipate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeParticipate_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeParticipate_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTrack",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmloyeeId = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    WorkingHours = table.Column<int>(type: "int", nullable: false),
                    PerformedWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedWork = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTrack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTrack_Employees_EmloyeeId",
                        column: x => x.EmloyeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTrack_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeParticipate_EmployeeId",
                table: "EmployeeParticipate",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeParticipate_ProjectId",
                table: "EmployeeParticipate",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTrack_EmloyeeId",
                table: "EmployeeTrack",
                column: "EmloyeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTrack_TrackId",
                table: "EmployeeTrack",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Tracks_TrackId",
                table: "Employees",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorks_Employees_EmployeeId",
                table: "EmployeeWorks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorks_StepTracks_StepTrackId",
                table: "EmployeeWorks",
                column: "StepTrackId",
                principalTable: "StepTracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Tracks_TrackId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorks_Employees_EmployeeId",
                table: "EmployeeWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorks_StepTracks_StepTrackId",
                table: "EmployeeWorks");

            migrationBuilder.DropTable(
                name: "EmployeeParticipate");

            migrationBuilder.DropTable(
                name: "EmployeeTrack");

            migrationBuilder.DropColumn(
                name: "ExecutionRatio",
                table: "StepTracks");

            migrationBuilder.DropColumn(
                name: "CurrentCompletionRatio",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Steps");

            migrationBuilder.RenameColumn(
                name: "TrackId",
                table: "Employees",
                newName: "StepId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_TrackId",
                table: "Employees",
                newName: "IX_Employees_StepId");

            migrationBuilder.AddColumn<int>(
                name: "StepId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_StepId",
                table: "Items",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Steps_StepId",
                table: "Employees",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorks_Employees_EmployeeId",
                table: "EmployeeWorks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorks_StepTracks_StepTrackId",
                table: "EmployeeWorks",
                column: "StepTrackId",
                principalTable: "StepTracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Steps_StepId",
                table: "Items",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
