using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class KopekDusumKopekTuruFiiliBirim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "KT_Birims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_Birims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UT_KopekCalKads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KopekId = table.Column<int>(type: "int", nullable: false),
                    T_GoreveBaslama = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_IlisikKesme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirimId = table.Column<int>(type: "int", nullable: false),
                    EvrakAtama = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtamaEvrakSayısı = table.Column<int>(type: "int", nullable: false),
                    IlkId = table.Column<int>(type: "int", nullable: false),
                    OncekiId = table.Column<int>(type: "int", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KopekCalKads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_KopekCalKads_KT_Birims_BirimId",
                        column: x => x.BirimId,
                        principalTable: "KT_Birims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UT_KopekCalKads_UT_Kopek_Kopeks_KopekId",
                        column: x => x.KopekId,
                        principalTable: "UT_Kopek_Kopeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_FiiliBirimId",
                table: "UT_Kopek_Kopeks",
                column: "FiiliBirimId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KopekCalKads_BirimId",
                table: "UT_KopekCalKads",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KopekCalKads_KopekId",
                table: "UT_KopekCalKads",
                column: "KopekId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_FiiliBirimId",
                table: "UT_Kopek_Kopeks",
                column: "FiiliBirimId",
                principalTable: "KT_Birims",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_FiiliBirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropTable(
                name: "UT_KopekCalKads");

            migrationBuilder.DropTable(
                name: "KT_Birims");

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
        }
    }
}
