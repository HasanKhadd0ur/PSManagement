using Microsoft.EntityFrameworkCore.Migrations;

namespace PSManagement.Infrastructure.Persistence.Migrations
{
    public partial class FixCustomerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_Customers_CustomerId",
                table: "ContactInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactInfo",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "ContactInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactInfo",
                table: "ContactInfo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_CustomerId",
                table: "ContactInfo",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_Customers_CustomerId",
                table: "ContactInfo",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_Customers_CustomerId",
                table: "ContactInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactInfo",
                table: "ContactInfo");

            migrationBuilder.DropIndex(
                name: "IX_ContactInfo_CustomerId",
                table: "ContactInfo");

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "ContactInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactInfo",
                table: "ContactInfo",
                columns: new[] { "CustomerId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_Customers_CustomerId",
                table: "ContactInfo",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
