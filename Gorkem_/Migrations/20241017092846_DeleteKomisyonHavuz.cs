using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class DeleteKomisyonHavuz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Komisyons_UT_KomisyonHavuz_UT_KomisyonHavuzId",
                table: "UT_Komisyons");

            migrationBuilder.DropTable(
                name: "UT_KomisyonHavuz");

            migrationBuilder.DropIndex(
                name: "IX_UT_Komisyons_UT_KomisyonHavuzId",
                table: "UT_Komisyons");

            migrationBuilder.DropColumn(
                name: "UT_KomisyonHavuzId",
                table: "UT_Komisyons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UT_KomisyonHavuzId",
                table: "UT_Komisyons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UT_KomisyonHavuz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KomisyonHavuz", x => x.Id);
                });

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
    }
}
