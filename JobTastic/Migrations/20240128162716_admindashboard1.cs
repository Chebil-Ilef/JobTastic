using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTastic.Migrations
{
    public partial class admindashboard1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminDashboardViewModel",
                table: "AdminDashboardViewModel");

            migrationBuilder.DropColumn(
                name: "AdminDashboardViewModelId",
                table: "AdminDashboardViewModel");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AdminDashboardViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminDashboardViewModel",
                table: "AdminDashboardViewModel",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminDashboardViewModel",
                table: "AdminDashboardViewModel");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AdminDashboardViewModel");

            migrationBuilder.AddColumn<string>(
                name: "AdminDashboardViewModelId",
                table: "AdminDashboardViewModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminDashboardViewModel",
                table: "AdminDashboardViewModel",
                column: "AdminDashboardViewModelId");
        }
    }
}
