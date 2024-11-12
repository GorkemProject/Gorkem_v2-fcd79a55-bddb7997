using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class addBirim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_FiiliBirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropIndex(
                name: "IX_UT_Kopek_Kopeks_FiiliBirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropColumn(
                name: "DusumSekli",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropColumn(
                name: "FiiliBirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropColumn(
                name: "KopekDusumNedeni",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropColumn(
                name: "KopekOlduMu",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropColumn(
                name: "KopekTuru",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.AddColumn<int>(
                name: "BirimId",
                table: "UT_Kopek_Kopeks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_BirimId",
                table: "UT_Kopek_Kopeks",
                column: "BirimId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimId",
                table: "UT_Kopek_Kopeks",
                column: "BirimId",
                principalTable: "KT_Birims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropIndex(
                name: "IX_UT_Kopek_Kopeks_BirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropColumn(
                name: "BirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.AddColumn<int>(
                name: "DusumSekli",
                table: "UT_Kopek_Kopeks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiiliBirimId",
                table: "UT_Kopek_Kopeks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KopekDusumNedeni",
                table: "UT_Kopek_Kopeks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "KopekOlduMu",
                table: "UT_Kopek_Kopeks",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KopekTuru",
                table: "UT_Kopek_Kopeks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_FiiliBirimId",
                table: "UT_Kopek_Kopeks",
                column: "FiiliBirimId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_FiiliBirimId",
                table: "UT_Kopek_Kopeks",
                column: "FiiliBirimId",
                principalTable: "KT_Birims",
                principalColumn: "Id");
        }
    }
}
