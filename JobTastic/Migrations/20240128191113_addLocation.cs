using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTastic.Migrations
{
    public partial class addLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminDashboardViewModel",
                table: "AdminDashboardViewModel");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AdminDashboardViewModel");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "JobOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "JobOffers");

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
    }
}
