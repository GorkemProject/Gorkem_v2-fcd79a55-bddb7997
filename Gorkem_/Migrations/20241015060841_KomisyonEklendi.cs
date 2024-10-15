using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class KomisyonEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UT_Komisyons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KomisyonAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GorevYeri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_Komisyons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UT_KomisyonUyeleris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TcKimlikNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sicil = table.Column<int>(type: "int", nullable: false),
                    GorevUnvani = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GorevYeri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CepTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KomisyonUyeleris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UT_KomisyonUyeAtama",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KomisyonId = table.Column<int>(type: "int", nullable: false),
                    KomisyonUyeId = table.Column<int>(type: "int", nullable: false),
                    KomisyonUyeleriId = table.Column<int>(type: "int", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_KomisyonUyeAtama");

            migrationBuilder.DropTable(
                name: "UT_KomisyonUyeleris");

            migrationBuilder.DropTable(
                name: "UT_Komisyons");
        }
    }
}
