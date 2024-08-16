using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSManagement.Infrastructure.Persistence.Migrations
{
    public partial class UpdateTrackDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkingHours",
                table: "EmployeeTrack");

            migrationBuilder.RenameColumn(
                name: "TrackNote",
                table: "Tracks",
                newName: "StatusDescription");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TrackDate",
                table: "Tracks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCompleted",
                table: "Tracks",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExecutionState",
                table: "StepTracks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AssignedWorkEnd",
                table: "EmployeeTrack",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignedWorkingHours",
                table: "EmployeeTrack",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContributingRatio",
                table: "EmployeeTrack",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "EmployeeTrack",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkedHours",
                table: "EmployeeTrack",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "ExecutionState",
                table: "StepTracks");

            migrationBuilder.DropColumn(
                name: "AssignedWorkEnd",
                table: "EmployeeTrack");

            migrationBuilder.DropColumn(
                name: "AssignedWorkingHours",
                table: "EmployeeTrack");

            migrationBuilder.DropColumn(
                name: "ContributingRatio",
                table: "EmployeeTrack");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "EmployeeTrack");

            migrationBuilder.DropColumn(
                name: "WorkedHours",
                table: "EmployeeTrack");

            migrationBuilder.RenameColumn(
                name: "StatusDescription",
                table: "Tracks",
                newName: "TrackNote");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TrackDate",
                table: "Tracks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsCompleted",
                table: "Tracks",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "WorkingHours",
                table: "EmployeeTrack",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
