using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class AddKursTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UT_Kurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    T_KursBaslangic = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_KursBitis = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KursYeriId = table.Column<int>(type: "int", nullable: true),
                    KursEgitimListesiId = table.Column<int>(type: "int", nullable: true),
                    Donem = table.Column<int>(type: "int", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_Kurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_Kurs_KT_GorevYeris_KursYeriId",
                        column: x => x.KursYeriId,
                        principalTable: "KT_GorevYeris",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UT_Kurs_KT_KursEgitimListesis_KursEgitimListesiId",
                        column: x => x.KursEgitimListesiId,
                        principalTable: "KT_KursEgitimListesis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kurs_KursEgitimListesiId",
                table: "UT_Kurs",
                column: "KursEgitimListesiId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kurs_KursYeriId",
                table: "UT_Kurs",
                column: "KursYeriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_Kurs");
        }
    }
}
