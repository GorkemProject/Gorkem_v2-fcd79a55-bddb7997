using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class DegerlendirmeToplamPuan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AracToplamPuan",
                table: "UT_KopekVeIdareciDegerlendirmeFormu");

            migrationBuilder.DropColumn(
                name: "KapaliAlanToplamPuan",
                table: "UT_KopekVeIdareciDegerlendirmeFormu");

            migrationBuilder.DropColumn(
                name: "TasinabilirEsyaToplamPuan",
                table: "UT_KopekVeIdareciDegerlendirmeFormu");

            migrationBuilder.AddColumn<int>(
                name: "KopekToplamPuan",
                table: "UT_Kursiyer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KursiyerToplamPuan",
                table: "UT_Kursiyer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KopekToplamPuan",
                table: "UT_Kursiyer");

            migrationBuilder.DropColumn(
                name: "KursiyerToplamPuan",
                table: "UT_Kursiyer");

            migrationBuilder.AddColumn<int>(
                name: "AracToplamPuan",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KapaliAlanToplamPuan",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TasinabilirEsyaToplamPuan",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                type: "int",
                nullable: true);
        }
    }
}
