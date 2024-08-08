using Microsoft.EntityFrameworkCore.Migrations;

namespace PSManagement.Infrastructure.Persistence.Migrations
{
    public partial class AddDomainsUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkJob",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkType",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FinincialSpending",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalPurchaseAmmount = table.Column<int>(type: "int", nullable: true),
                    LocalPurchaseCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "SP"),
                    ExternalPurchaseAmmount = table.Column<int>(type: "int", nullable: true),
                    ExternalPurchaseCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "USD"),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinincialSpending", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinincialSpending_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinincialSpending_ProjectId",
                table: "FinincialSpending",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinincialSpending");

            migrationBuilder.DropColumn(
                name: "WorkJob",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkType",
                table: "Employees");
        }
    }
}
