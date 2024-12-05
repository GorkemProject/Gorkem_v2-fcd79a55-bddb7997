using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKursGunlukRapor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_KGRMufredatUT_KursGunlukRapor");

            migrationBuilder.DropTable(
                name: "UT_KGRMufredats");

            migrationBuilder.AlterColumn<string>(
                name: "TestinYapildigiYer",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "UT_KursGunlukRaporDersler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursGunlukRaporId = table.Column<int>(type: "int", nullable: false),
                    DersId = table.Column<int>(type: "int", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KursGunlukRaporDersler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_KursGunlukRaporDersler_KT_KursMufredats_DersId",
                        column: x => x.DersId,
                        principalTable: "KT_KursMufredats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KursGunlukRaporDersler_UT_KursGunlukRapors_KursGunlukRaporId",
                        column: x => x.KursGunlukRaporId,
                        principalTable: "UT_KursGunlukRapors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursGunlukRaporDersler_DersId",
                table: "UT_KursGunlukRaporDersler",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursGunlukRaporDersler_KursGunlukRaporId",
                table: "UT_KursGunlukRaporDersler",
                column: "KursGunlukRaporId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_KursGunlukRaporDersler");

            migrationBuilder.AlterColumn<string>(
                name: "TestinYapildigiYer",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UT_KGRMufredats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MufredatId = table.Column<int>(type: "int", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KGRMufredats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_KGRMufredats_KT_KursMufredats_MufredatId",
                        column: x => x.MufredatId,
                        principalTable: "KT_KursMufredats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UT_KGRMufredatUT_KursGunlukRapor",
                columns: table => new
                {
                    KGRMufredatlarId = table.Column<int>(type: "int", nullable: false),
                    KursGunlukRaporId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KGRMufredatUT_KursGunlukRapor", x => new { x.KGRMufredatlarId, x.KursGunlukRaporId });
                    table.ForeignKey(
                        name: "FK_UT_KGRMufredatUT_KursGunlukRapor_UT_KGRMufredats_KGRMufredatlarId",
                        column: x => x.KGRMufredatlarId,
                        principalTable: "UT_KGRMufredats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KGRMufredatUT_KursGunlukRapor_UT_KursGunlukRapors_KursGunlukRaporId",
                        column: x => x.KursGunlukRaporId,
                        principalTable: "UT_KursGunlukRapors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_KGRMufredats_MufredatId",
                table: "UT_KGRMufredats",
                column: "MufredatId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KGRMufredatUT_KursGunlukRapor_KursGunlukRaporId",
                table: "UT_KGRMufredatUT_KursGunlukRapor",
                column: "KursGunlukRaporId");
        }
    }
}
