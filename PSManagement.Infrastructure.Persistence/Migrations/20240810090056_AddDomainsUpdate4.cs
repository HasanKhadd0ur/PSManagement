using Microsoft.EntityFrameworkCore.Migrations;

namespace PSManagement.Infrastructure.Persistence.Migrations
{
    public partial class AddDomainsUpdate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinincialSpending_Projects_ProjectId",
                table: "FinincialSpending");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinincialSpending",
                table: "FinincialSpending");

            migrationBuilder.DropColumn(
                name: "LocalPurchaseAmmount",
                table: "FinincialSpending");

            migrationBuilder.DropColumn(
                name: "LocalPurchaseCurrency",
                table: "FinincialSpending");

            migrationBuilder.RenameTable(
                name: "FinincialSpending",
                newName: "FinancialSpending");

            migrationBuilder.RenameIndex(
                name: "IX_FinincialSpending_ProjectId",
                table: "FinancialSpending",
                newName: "IX_FinancialSpending_ProjectId");

            migrationBuilder.AddColumn<int>(
                name: "LocalPurchase",
                table: "FinancialSpending",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialSpending",
                table: "FinancialSpending",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "قسم المعلوميات" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "قسم النظم الإلكترونيى" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "شؤون الطلاب" });

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialSpending_Projects_ProjectId",
                table: "FinancialSpending",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialSpending_Projects_ProjectId",
                table: "FinancialSpending");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialSpending",
                table: "FinancialSpending");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "LocalPurchase",
                table: "FinancialSpending");

            migrationBuilder.RenameTable(
                name: "FinancialSpending",
                newName: "FinincialSpending");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialSpending_ProjectId",
                table: "FinincialSpending",
                newName: "IX_FinincialSpending_ProjectId");

            migrationBuilder.AddColumn<int>(
                name: "LocalPurchaseAmmount",
                table: "FinincialSpending",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalPurchaseCurrency",
                table: "FinincialSpending",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "SP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinincialSpending",
                table: "FinincialSpending",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinincialSpending_Projects_ProjectId",
                table: "FinincialSpending",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
