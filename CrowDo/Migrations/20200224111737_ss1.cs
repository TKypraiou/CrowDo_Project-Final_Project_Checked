using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowDo.Migrations
{
    public partial class ss1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_UserId",
                schema: "core",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "core",
                table: "Project",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                schema: "core",
                table: "FundingPackage",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FundingPackage_ProjectId",
                schema: "core",
                table: "FundingPackage",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundingPackage_Project_ProjectId",
                schema: "core",
                table: "FundingPackage",
                column: "ProjectId",
                principalSchema: "core",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_UserId",
                schema: "core",
                table: "Project",
                column: "UserId",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundingPackage_Project_ProjectId",
                schema: "core",
                table: "FundingPackage");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_UserId",
                schema: "core",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_FundingPackage_ProjectId",
                schema: "core",
                table: "FundingPackage");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "core",
                table: "FundingPackage");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "core",
                table: "Project",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_UserId",
                schema: "core",
                table: "Project",
                column: "UserId",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
