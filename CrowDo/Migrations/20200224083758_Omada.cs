using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowDo.Migrations
{
    public partial class Omada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "core");

            migrationBuilder.CreateTable(
                name: "FundingPackage",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deposit = table.Column<decimal>(nullable: false),
                    DescriptionGift = table.Column<string>(nullable: true),
                    FixedPackageAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingPackage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    YearOfBirth = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Budget = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    StatusProject = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFundingPackage",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepositDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    FundingPackageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFundingPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectFundingPackage_FundingPackage_FundingPackageId",
                        column: x => x.FundingPackageId,
                        principalSchema: "core",
                        principalTable: "FundingPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectFundingPackage_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "core",
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectFundingPackage_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_UserId",
                schema: "core",
                table: "Project",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFundingPackage_FundingPackageId",
                schema: "core",
                table: "ProjectFundingPackage",
                column: "FundingPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFundingPackage_ProjectId",
                schema: "core",
                table: "ProjectFundingPackage",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFundingPackage_UserId",
                schema: "core",
                table: "ProjectFundingPackage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "core",
                table: "User",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectFundingPackage",
                schema: "core");

            migrationBuilder.DropTable(
                name: "FundingPackage",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "core");

            migrationBuilder.DropTable(
                name: "User",
                schema: "core");
        }
    }
}
