using Microsoft.EntityFrameworkCore.Migrations;

namespace PSManagement.Infrastructure.Persistence.Migrations
{
    public partial class AddCustomer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                table: "Customers",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "Address_StreetNumber",
                table: "Customers",
                newName: "StreetNumber");

            migrationBuilder.RenameColumn(
                name: "Address_StreetName",
                table: "Customers",
                newName: "StreetName");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Customers",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber_Number",
                table: "ContactInfo",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "MobileNumber_Number",
                table: "ContactInfo",
                newName: "MobileNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Customers",
                newName: "Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "StreetNumber",
                table: "Customers",
                newName: "Address_StreetNumber");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "Customers",
                newName: "Address_StreetName");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Customers",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "ContactInfo",
                newName: "PhoneNumber_Number");

            migrationBuilder.RenameColumn(
                name: "MobileNumber",
                table: "ContactInfo",
                newName: "MobileNumber_Number");
        }
    }
}
