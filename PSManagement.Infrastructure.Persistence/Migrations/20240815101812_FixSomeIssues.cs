using Microsoft.EntityFrameworkCore.Migrations;

namespace PSManagement.Infrastructure.Persistence.Migrations
{
    public partial class FixSomeIssues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialSpending_Projects_ProjectId",
                table: "FinancialSpending");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialSpending",
                table: "FinancialSpending");

            migrationBuilder.RenameTable(
                name: "FinancialSpending",
                newName: "FinancialSpendings");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialSpending_ProjectId",
                table: "FinancialSpendings",
                newName: "IX_FinancialSpendings_ProjectId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "FinancialSpendings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialSpendings",
                table: "FinancialSpendings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialSpendings_Projects_ProjectId",
                table: "FinancialSpendings",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialSpendings_Projects_ProjectId",
                table: "FinancialSpendings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialSpendings",
                table: "FinancialSpendings");

            migrationBuilder.RenameTable(
                name: "FinancialSpendings",
                newName: "FinancialSpending");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialSpendings_ProjectId",
                table: "FinancialSpending",
                newName: "IX_FinancialSpending_ProjectId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "FinancialSpending",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialSpending",
                table: "FinancialSpending",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialSpending_Projects_ProjectId",
                table: "FinancialSpending",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
