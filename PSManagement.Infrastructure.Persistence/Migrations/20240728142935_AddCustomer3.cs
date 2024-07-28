using Microsoft.EntityFrameworkCore.Migrations;

namespace PSManagement.Infrastructure.Persistence.Migrations
{
    public partial class AddCustomer3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ContactInfo");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "ContactInfo",
                newName: "ContactType");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConatctValue",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ConatctValue",
                table: "ContactInfo");

            migrationBuilder.RenameColumn(
                name: "ContactType",
                table: "ContactInfo",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "MobileNumber",
                table: "ContactInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "ContactInfo",
                type: "int",
                nullable: true);
        }
    }
}
