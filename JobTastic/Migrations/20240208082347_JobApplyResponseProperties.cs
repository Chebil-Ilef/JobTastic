using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTastic.Migrations
{
    public partial class JobApplyResponseProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "handled",
                table: "JobApplies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "respond",
                table: "JobApplies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "result",
                table: "JobApplies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "sent",
                table: "JobApplies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "handled",
                table: "JobApplies");

            migrationBuilder.DropColumn(
                name: "respond",
                table: "JobApplies");

            migrationBuilder.DropColumn(
                name: "result",
                table: "JobApplies");

            migrationBuilder.DropColumn(
                name: "sent",
                table: "JobApplies");
        }
    }
}
