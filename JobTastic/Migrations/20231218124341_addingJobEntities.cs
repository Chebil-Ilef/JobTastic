using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTastic.Migrations
{
    public partial class addingJobEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobCategories",
                columns: table => new
                {
                    JobCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategories", x => x.JobCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    JobTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.JobTypeId);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    jobOfferId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    authorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Submitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEdit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.jobOfferId);
                    table.ForeignKey(
                        name: "FK_JobOffers_AspNetUsers_authorId",
                        column: x => x.authorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOffers_JobCategories_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategories",
                        principalColumn: "JobCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOffers_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "JobTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_authorId",
                table: "JobOffers",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_JobCategoryId",
                table: "JobOffers",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_JobTypeId",
                table: "JobOffers",
                column: "JobTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobOffers");

            migrationBuilder.DropTable(
                name: "JobCategories");

            migrationBuilder.DropTable(
                name: "JobTypes");
        }
    }
}
