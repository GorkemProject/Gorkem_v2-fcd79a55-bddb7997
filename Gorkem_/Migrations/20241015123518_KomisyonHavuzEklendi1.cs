using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class KomisyonHavuzEklendi1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KomisyonUyeleris_UT_KomisyonHavuz_UT_KomisyonHavuzId",
                table: "UT_KomisyonUyeleris");

            migrationBuilder.DropIndex(
                name: "IX_UT_KomisyonUyeleris_UT_KomisyonHavuzId",
                table: "UT_KomisyonUyeleris");

            migrationBuilder.DropColumn(
                name: "UT_KomisyonHavuzId",
                table: "UT_KomisyonUyeleris");

            migrationBuilder.AddColumn<int>(
                name: "UT_KomisyonHavuzId",
                table: "UT_Komisyons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UT_Komisyons_UT_KomisyonHavuzId",
                table: "UT_Komisyons",
                column: "UT_KomisyonHavuzId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Komisyons_UT_KomisyonHavuz_UT_KomisyonHavuzId",
                table: "UT_Komisyons",
                column: "UT_KomisyonHavuzId",
                principalTable: "UT_KomisyonHavuz",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Komisyons_UT_KomisyonHavuz_UT_KomisyonHavuzId",
                table: "UT_Komisyons");

            migrationBuilder.DropIndex(
                name: "IX_UT_Komisyons_UT_KomisyonHavuzId",
                table: "UT_Komisyons");

            migrationBuilder.DropColumn(
                name: "UT_KomisyonHavuzId",
                table: "UT_Komisyons");

            migrationBuilder.AddColumn<int>(
                name: "UT_KomisyonHavuzId",
                table: "UT_KomisyonUyeleris",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UT_KomisyonUyeleris_UT_KomisyonHavuzId",
                table: "UT_KomisyonUyeleris",
                column: "UT_KomisyonHavuzId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KomisyonUyeleris_UT_KomisyonHavuz_UT_KomisyonHavuzId",
                table: "UT_KomisyonUyeleris",
                column: "UT_KomisyonHavuzId",
                principalTable: "UT_KomisyonHavuz",
                principalColumn: "Id");
        }
    }
}
