using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTastic.Migrations
{
    public partial class admindashboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminDashboardViewModel",
                columns: table => new
                {
                    TodaysOffers = table.Column<int>(type: "int", nullable: false),
                    TotalOffers = table.Column<int>(type: "int", nullable: false),
                    NumberOfRecruiters = table.Column<int>(type: "int", nullable: false),
                    NumberOfJobSearchers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminDashboardViewModel");
        }
    }
}
