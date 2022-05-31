using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ipcam.Migrations
{
    public partial class TariffTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tariff_Resolution_PeriodId",
                table: "Tariff");

            migrationBuilder.AddForeignKey(
                name: "FK_Tariff_Period_PeriodId",
                table: "Tariff",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tariff_Period_PeriodId",
                table: "Tariff");

            migrationBuilder.AddForeignKey(
                name: "FK_Tariff_Resolution_PeriodId",
                table: "Tariff",
                column: "PeriodId",
                principalTable: "Resolution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
