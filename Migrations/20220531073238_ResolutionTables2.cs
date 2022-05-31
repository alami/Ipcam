using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ipcam.Migrations
{
    public partial class ResolutionTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Resolutions",
                table: "Resolutions");

            migrationBuilder.RenameTable(
                name: "Resolutions",
                newName: "Resolution");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resolution",
                table: "Resolution",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Resolution",
                table: "Resolution");

            migrationBuilder.RenameTable(
                name: "Resolution",
                newName: "Resolutions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resolutions",
                table: "Resolutions",
                column: "Id");
        }
    }
}
