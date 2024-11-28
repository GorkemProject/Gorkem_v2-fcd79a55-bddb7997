using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class KopekVeIdareciDegerlendirmeFormu1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KursKopekDegerlendirmeCevap_KT_KursKopekDegerlendirmeSorular_KopekDegerlendirmeSorularId",
                table: "UT_KursKopekDegerlendirmeCevap");

            migrationBuilder.DropIndex(
                name: "IX_UT_KursKopekDegerlendirmeCevap_KopekDegerlendirmeSorularId",
                table: "UT_KursKopekDegerlendirmeCevap");

            migrationBuilder.DropColumn(
                name: "KopekDegerlendirmeSorularId",
                table: "UT_KursKopekDegerlendirmeCevap");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursKopekDegerlendirmeCevap_KopekDegerlendirmeSoruId",
                table: "UT_KursKopekDegerlendirmeCevap",
                column: "KopekDegerlendirmeSoruId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KursKopekDegerlendirmeCevap_KT_KursKopekDegerlendirmeSorular_KopekDegerlendirmeSoruId",
                table: "UT_KursKopekDegerlendirmeCevap",
                column: "KopekDegerlendirmeSoruId",
                principalTable: "KT_KursKopekDegerlendirmeSorular",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KursKopekDegerlendirmeCevap_KT_KursKopekDegerlendirmeSorular_KopekDegerlendirmeSoruId",
                table: "UT_KursKopekDegerlendirmeCevap");

            migrationBuilder.DropIndex(
                name: "IX_UT_KursKopekDegerlendirmeCevap_KopekDegerlendirmeSoruId",
                table: "UT_KursKopekDegerlendirmeCevap");

            migrationBuilder.AddColumn<int>(
                name: "KopekDegerlendirmeSorularId",
                table: "UT_KursKopekDegerlendirmeCevap",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursKopekDegerlendirmeCevap_KopekDegerlendirmeSorularId",
                table: "UT_KursKopekDegerlendirmeCevap",
                column: "KopekDegerlendirmeSorularId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KursKopekDegerlendirmeCevap_KT_KursKopekDegerlendirmeSorular_KopekDegerlendirmeSorularId",
                table: "UT_KursKopekDegerlendirmeCevap",
                column: "KopekDegerlendirmeSorularId",
                principalTable: "KT_KursKopekDegerlendirmeSorular",
                principalColumn: "Id");
        }
    }
}
