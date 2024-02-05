using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTastic.Migrations
{
    public partial class addSelectedRole : Migration
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
