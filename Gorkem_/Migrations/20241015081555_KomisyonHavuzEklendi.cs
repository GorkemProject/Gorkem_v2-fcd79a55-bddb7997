using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class KomisyonHavuzEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_KomisyonUyeAtama");

            migrationBuilder.AlterColumn<int>(
                name: "Sicil",
                table: "UT_KomisyonUyeleris",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UT_KomisyonHavuzId",
                table: "UT_KomisyonUyeleris",
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

            migrationBuilder.CreateTable(
                name: "UT_KomisyonUT_KomisyonUyeleri",
                columns: table => new
                {
                    KomisyonId = table.Column<int>(type: "int", nullable: false),
                    KomisyonUyeleriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KomisyonUT_KomisyonUyeleri", x => new { x.KomisyonId, x.KomisyonUyeleriId });
                    table.ForeignKey(
                        name: "FK_UT_KomisyonUT_KomisyonUyeleri_UT_KomisyonUyeleris_KomisyonUyeleriId",
                        column: x => x.KomisyonUyeleriId,
                        principalTable: "UT_KomisyonUyeleris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KomisyonUT_KomisyonUyeleri_UT_Komisyons_KomisyonId",
                        column: x => x.KomisyonId,
                        principalTable: "UT_Komisyons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_KomisyonUyeleris_UT_KomisyonHavuzId",
                table: "UT_KomisyonUyeleris",
                column: "UT_KomisyonHavuzId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KomisyonUT_KomisyonUyeleri_KomisyonUyeleriId",
                table: "UT_KomisyonUT_KomisyonUyeleri",
                column: "KomisyonUyeleriId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KomisyonUyeleris_UT_KomisyonHavuz_UT_KomisyonHavuzId",
                table: "UT_KomisyonUyeleris",
                column: "UT_KomisyonHavuzId",
                principalTable: "UT_KomisyonHavuz",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KomisyonUyeleris_UT_KomisyonHavuz_UT_KomisyonHavuzId",
                table: "UT_KomisyonUyeleris");

            migrationBuilder.DropTable(
                name: "UT_KomisyonHavuz");

            migrationBuilder.DropTable(
                name: "UT_KomisyonUT_KomisyonUyeleri");

            migrationBuilder.DropIndex(
                name: "IX_UT_KomisyonUyeleris_UT_KomisyonHavuzId",
                table: "UT_KomisyonUyeleris");

            migrationBuilder.DropColumn(
                name: "UT_KomisyonHavuzId",
                table: "UT_KomisyonUyeleris");

            migrationBuilder.AlterColumn<int>(
                name: "Sicil",
                table: "UT_KomisyonUyeleris",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UT_KomisyonUyeAtama",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KomisyonId = table.Column<int>(type: "int", nullable: false),
                    KomisyonUyeleriId = table.Column<int>(type: "int", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    KomisyonUyeId = table.Column<int>(type: "int", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KomisyonUyeAtama", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_KomisyonUyeAtama_UT_KomisyonUyeleris_KomisyonUyeleriId",
                        column: x => x.KomisyonUyeleriId,
                        principalTable: "UT_KomisyonUyeleris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KomisyonUyeAtama_UT_Komisyons_KomisyonId",
                        column: x => x.KomisyonId,
                        principalTable: "UT_Komisyons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_KomisyonUyeAtama_KomisyonId",
                table: "UT_KomisyonUyeAtama",
                column: "KomisyonId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KomisyonUyeAtama_KomisyonUyeleriId",
                table: "UT_KomisyonUyeAtama",
                column: "KomisyonUyeleriId");
        }
    }
}
