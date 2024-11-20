using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class KopekKursAddKGR2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UT_KGRMufredatId",
                table: "KT_KursMufredats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UT_KursGunlukRapors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursId = table.Column<int>(type: "int", nullable: false),
                    T_DersTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SinifAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KursGunlukRapors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_KursGunlukRapors_UT_Kurs_KursId",
                        column: x => x.KursId,
                        principalTable: "UT_Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UT_KGRMufredats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UT_KursGunlukRaporId = table.Column<int>(type: "int", nullable: true),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KGRMufredats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_KGRMufredats_UT_KursGunlukRapors_UT_KursGunlukRaporId",
                        column: x => x.UT_KursGunlukRaporId,
                        principalTable: "UT_KursGunlukRapors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KT_KursMufredats_UT_KGRMufredatId",
                table: "KT_KursMufredats",
                column: "UT_KGRMufredatId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KGRMufredats_UT_KursGunlukRaporId",
                table: "UT_KGRMufredats",
                column: "UT_KursGunlukRaporId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursGunlukRapors_KursId",
                table: "UT_KursGunlukRapors",
                column: "KursId");

            migrationBuilder.AddForeignKey(
                name: "FK_KT_KursMufredats_UT_KGRMufredats_UT_KGRMufredatId",
                table: "KT_KursMufredats",
                column: "UT_KGRMufredatId",
                principalTable: "UT_KGRMufredats",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KT_KursMufredats_UT_KGRMufredats_UT_KGRMufredatId",
                table: "KT_KursMufredats");

            migrationBuilder.DropTable(
                name: "UT_KGRMufredats");

            migrationBuilder.DropTable(
                name: "UT_KursGunlukRapors");

            migrationBuilder.DropIndex(
                name: "IX_KT_KursMufredats_UT_KGRMufredatId",
                table: "KT_KursMufredats");

            migrationBuilder.DropColumn(
                name: "UT_KGRMufredatId",
                table: "KT_KursMufredats");
        }
    }
}
