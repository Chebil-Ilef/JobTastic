using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.Metrics;

#nullable disable

namespace JobTastic.Migrations
{
    public partial class AddedRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SelectedRole",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedRole",
                table: "AspNetUsers");
        }
    }
}
