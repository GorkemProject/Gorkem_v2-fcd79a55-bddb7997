using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class GuncelDegerlendirmeFormu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_KopekVeIdareciDegerlendirmeFormuUT_KursKopekDegerlendirmeCevap");

            migrationBuilder.DropTable(
                name: "UT_KopekVeIdareciDegerlendirmeFormuUT_KursKursiyerDegerlendirmeCevap");

            migrationBuilder.DropTable(
                name: "UT_KursKopekDegerlendirmeCevap");

            migrationBuilder.DropTable(
                name: "UT_KursKursiyerDegerlendirmeCevap");

            migrationBuilder.DropTable(
                name: "KT_KursKopekDegerlendirmeSorular");

            migrationBuilder.DropTable(
                name: "KT_KursKursiyerDegerlendirmeSorular");

            migrationBuilder.CreateTable(
                name: "KT_KursDegerlendirmeSorular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxPuan = table.Column<int>(type: "int", nullable: false),
                    DegerlendirmeTuru = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_KursDegerlendirmeSorular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UT_KursrDegerlendirmeCevap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegerlendirmeSoruId = table.Column<int>(type: "int", nullable: false),
                    KapaliAlanPuan = table.Column<int>(type: "int", nullable: false),
                    AracPuan = table.Column<int>(type: "int", nullable: false),
                    TasinabilirEsyaPuan = table.Column<int>(type: "int", nullable: false),
                    DegerlendirmeTuru = table.Column<int>(type: "int", nullable: false),
                    DegerlendirilenVarlikId = table.Column<int>(type: "int", nullable: false),
                    UT_KopekVeIdareciDegerlendirmeFormuId = table.Column<int>(type: "int", nullable: true),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KursrDegerlendirmeCevap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_KursrDegerlendirmeCevap_KT_KursDegerlendirmeSorular_DegerlendirmeSoruId",
                        column: x => x.DegerlendirmeSoruId,
                        principalTable: "KT_KursDegerlendirmeSorular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KursrDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormu_UT_KopekVeIdareciDegerlendirmeFormuId",
                        column: x => x.UT_KopekVeIdareciDegerlendirmeFormuId,
                        principalTable: "UT_KopekVeIdareciDegerlendirmeFormu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursrDegerlendirmeCevap_DegerlendirmeSoruId",
                table: "UT_KursrDegerlendirmeCevap",
                column: "DegerlendirmeSoruId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursrDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursrDegerlendirmeCevap",
                column: "UT_KopekVeIdareciDegerlendirmeFormuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_KursrDegerlendirmeCevap");

            migrationBuilder.DropTable(
                name: "KT_KursDegerlendirmeSorular");

            migrationBuilder.CreateTable(
                name: "KT_KursKopekDegerlendirmeSorular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    MaxPuan = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_KursKopekDegerlendirmeSorular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KT_KursKursiyerDegerlendirmeSorular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    MaxPuan = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_KursKursiyerDegerlendirmeSorular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UT_KursKopekDegerlendirmeCevap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KopekDegerlendirmeSoruId = table.Column<int>(type: "int", nullable: false),
                    KopekId = table.Column<int>(type: "int", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    AracPuan = table.Column<int>(type: "int", nullable: false),
                    KapaliAlanPuan = table.Column<int>(type: "int", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TasinabilirEsyaPuan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KursKopekDegerlendirmeCevap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_KursKopekDegerlendirmeCevap_KT_KursKopekDegerlendirmeSorular_KopekDegerlendirmeSoruId",
                        column: x => x.KopekDegerlendirmeSoruId,
                        principalTable: "KT_KursKopekDegerlendirmeSorular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KursKopekDegerlendirmeCevap_UT_Kopek_Kopeks_KopekId",
                        column: x => x.KopekId,
                        principalTable: "UT_Kopek_Kopeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UT_KursKursiyerDegerlendirmeCevap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursiyerDegerlendirmeSoruId = table.Column<int>(type: "int", nullable: false),
                    KursiyerId = table.Column<int>(type: "int", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    AracPuan = table.Column<int>(type: "int", nullable: false),
                    KapaliAlanPuan = table.Column<int>(type: "int", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TasinabilirEsyaPuan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KursKursiyerDegerlendirmeCevap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_KursKursiyerDegerlendirmeCevap_KT_KursKursiyerDegerlendirmeSorular_KursiyerDegerlendirmeSoruId",
                        column: x => x.KursiyerDegerlendirmeSoruId,
                        principalTable: "KT_KursKursiyerDegerlendirmeSorular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KursKursiyerDegerlendirmeCevap_UT_Kursiyer_KursiyerId",
                        column: x => x.KursiyerId,
                        principalTable: "UT_Kursiyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UT_KopekVeIdareciDegerlendirmeFormuUT_KursKopekDegerlendirmeCevap",
                columns: table => new
                {
                    KopekDegerlendirmeCevaplarId = table.Column<int>(type: "int", nullable: false),
                    KopekVeIdareciDegerlendirmeFormuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKopekDegerlendirmeCevap", x => new { x.KopekDegerlendirmeCevaplarId, x.KopekVeIdareciDegerlendirmeFormuId });
                    table.ForeignKey(
                        name: "FK_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKopekDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormu_KopekVeIdareciDegerlen~",
                        column: x => x.KopekVeIdareciDegerlendirmeFormuId,
                        principalTable: "UT_KopekVeIdareciDegerlendirmeFormu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKopekDegerlendirmeCevap_UT_KursKopekDegerlendirmeCevap_KopekDegerlendirmeCevaplarId",
                        column: x => x.KopekDegerlendirmeCevaplarId,
                        principalTable: "UT_KursKopekDegerlendirmeCevap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UT_KopekVeIdareciDegerlendirmeFormuUT_KursKursiyerDegerlendirmeCevap",
                columns: table => new
                {
                    KopekVeIdareciDegerlendirmeFormuId = table.Column<int>(type: "int", nullable: false),
                    KursiyerDegerlendirmeCevaplarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKursiyerDegerlendirmeCevap", x => new { x.KopekVeIdareciDegerlendirmeFormuId, x.KursiyerDegerlendirmeCevaplarId });
                    table.ForeignKey(
                        name: "FK_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKursiyerDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormu_KopekVeIdareciDeger~",
                        column: x => x.KopekVeIdareciDegerlendirmeFormuId,
                        principalTable: "UT_KopekVeIdareciDegerlendirmeFormu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKursiyerDegerlendirmeCevap_UT_KursKursiyerDegerlendirmeCevap_KursiyerDegerlendirme~",
                        column: x => x.KursiyerDegerlendirmeCevaplarId,
                        principalTable: "UT_KursKursiyerDegerlendirmeCevap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKopekDegerlendirmeCevap_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KopekVeIdareciDegerlendirmeFormuUT_KursKopekDegerlendirmeCevap",
                column: "KopekVeIdareciDegerlendirmeFormuId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKursiyerDegerlendirmeCevap_KursiyerDegerlendirmeCevaplarId",
                table: "UT_KopekVeIdareciDegerlendirmeFormuUT_KursKursiyerDegerlendirmeCevap",
                column: "KursiyerDegerlendirmeCevaplarId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursKopekDegerlendirmeCevap_KopekDegerlendirmeSoruId",
                table: "UT_KursKopekDegerlendirmeCevap",
                column: "KopekDegerlendirmeSoruId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursKopekDegerlendirmeCevap_KopekId",
                table: "UT_KursKopekDegerlendirmeCevap",
                column: "KopekId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursKursiyerDegerlendirmeCevap_KursiyerDegerlendirmeSoruId",
                table: "UT_KursKursiyerDegerlendirmeCevap",
                column: "KursiyerDegerlendirmeSoruId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursKursiyerDegerlendirmeCevap_KursiyerId",
                table: "UT_KursKursiyerDegerlendirmeCevap",
                column: "KursiyerId");
        }
    }
}
