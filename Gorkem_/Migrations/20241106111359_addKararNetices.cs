using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class addKararNetices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_FiiliBirims_FiiliBirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.AddColumn<int>(
                name: "AtamaTuru",
                table: "UT_KopekCalKads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdareciId",
                table: "UT_KopekCalKads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KopekDurum",
                table: "UT_Kopek_Kopeks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Neticesi",
                table: "KT_Karars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_UT_KopekCalKads_IdareciId",
                table: "UT_KopekCalKads",
                column: "IdareciId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_FiiliBirimId",
                table: "UT_Kopek_Kopeks",
                column: "FiiliBirimId",
                principalTable: "KT_Birims",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idarecis_IdareciId",
                table: "UT_KopekCalKads",
                column: "IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_FiiliBirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idarecis_IdareciId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropIndex(
                name: "IX_UT_KopekCalKads_IdareciId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropColumn(
                name: "AtamaTuru",
                table: "UT_KopekCalKads");

            migrationBuilder.DropColumn(
                name: "IdareciId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropColumn(
                name: "KopekDurum",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropColumn(
                name: "Neticesi",
                table: "KT_Karars");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_FiiliBirims_FiiliBirimId",
                table: "UT_Kopek_Kopeks",
                column: "FiiliBirimId",
                principalTable: "KT_FiiliBirims",
                principalColumn: "Id");
        }
    }
}
