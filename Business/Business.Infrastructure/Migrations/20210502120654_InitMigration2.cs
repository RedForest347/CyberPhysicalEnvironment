using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.Infrastructure.Migrations
{
    public partial class InitMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInfos",
                table: "PersonInfos");

            migrationBuilder.RenameTable(
                name: "PersonInfos",
                newName: "BusinessInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessInfos",
                table: "BusinessInfos",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessInfos",
                table: "BusinessInfos");

            migrationBuilder.RenameTable(
                name: "BusinessInfos",
                newName: "PersonInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInfos",
                table: "PersonInfos",
                column: "Id");
        }
    }
}
